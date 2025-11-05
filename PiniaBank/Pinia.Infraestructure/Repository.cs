using System.Text;
using Newtonsoft.Json;

namespace Pinia.Infraestructure;

public abstract class Repository
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    protected Repository()
    {
        const string databaseUrl = "pinia-cangulor8.aws-us-east-1.turso.io";
        const string authToken =
            "eyJhbGciOiJFZERTQSIsInR5cCI6IkpXVCJ9.eyJhIjoicnciLCJpYXQiOjE3NjIzMTEzMjYsImlkIjoiYTc1YjhjNzItNjBhMC00YTE1LWFkNjAtNTZlZWY2ZWY4MGRkIiwicmlkIjoiNGM4ZWM2ZDQtNjc4Yi00MzZhLTk4M2QtNjE4NWFhMTNkMTFjIn0.bLEnPkSa4NVOpozkBfgJQiqzb2maSrY3CpgZdsGWBBQWkvI8_Zld7jrTOOkaKQIQGdhT0ZOAjZ_0szOrGbg-DQ";

        _baseUrl = $"https://{databaseUrl}";
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
    }

    protected async Task<int> ExecuteAsync(string sql, Dictionary<string, object>? parameters = null)
    {
        var requests = new List<object>
        {
            new
            {
                type = "execute",
                stmt = new
                {
                    sql,
                    named_args = parameters != null ? ConvertToNamedArgs(parameters) : null
                }
            }
        };

        var requestBody = new { requests };
        var json = JsonConvert.SerializeObject(requestBody, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseUrl}/v2/pipeline", content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();

            throw new HttpRequestException($"Error {response.StatusCode}: {errorContent}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();


        var result = JsonConvert.DeserializeObject<TursoPipelineResponse>(responseContent);

        if (result?.Results?[0].Error != null)
        {
            throw new Exception($"Turso error: {result.Results[0].Error?.Message}");
        }

        return result?.Results?[0].Response?.Result?.AffectedRowCount ?? 0;
    }

    protected async Task<List<T>> QueryAsync<T>(string sql, Dictionary<string, object>? parameters = null)
    {
        var requests = new List<object>
        {
            new
            {
                type = "execute",
                stmt = new
                {
                    sql,
                    named_args = parameters != null ? ConvertToNamedArgs(parameters) : null
                }
            }
        };

        var requestBody = new { requests };
        var json = JsonConvert.SerializeObject(requestBody, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseUrl}/v2/pipeline", content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();

            throw new HttpRequestException($"Error {response.StatusCode}: {errorContent}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TursoPipelineResponse>(responseContent);

        // Verificar errores
        if (result?.Results?.Count > 0 && result.Results[0].Type == "error")
        {
            throw new Exception($"Turso error: {result.Results[0].Error?.Message}");
        }

        var rows = result?.Results?[0].Response?.Result?.Rows ?? [];
        var columns = result?.Results?[0].Response?.Result?.Columns ?? [];

        return MapRowsToObjects<T>(rows, columns);
    }

    public async Task<T?> QuerySingleAsync<T>(string sql, Dictionary<string, object>? parameters = null)
    {
        var results = await QueryAsync<T>(sql, parameters);
        return results.FirstOrDefault();
    }

    private static List<object> ConvertToNamedArgs(Dictionary<string, object> parameters)
    {
        var namedArgs = new List<object>();

        foreach (var param in parameters)
        {
            // Determinar el tipo del valor
            var valueType = GetValueType(param.Value);

            namedArgs.Add(new
            {
                name = param.Key.Replace("@", "").Replace(":", "").Replace("$", ""), // Limpiar prefijos
                value = new
                {
                    type = valueType,
                    value = param.Value.ToString()
                }
            });
        }

        return namedArgs;
    }

    private static string GetValueType(object? value)
    {
        if (value == null) return "null";

        return value switch
        {
            int or long => "integer",
            double or float or decimal => "float",
            bool => "integer", // SQLite no tiene tipo boolean, usa 0/1
            DateTime => "text",
            _ => "text"
        };
    }

    private static List<T> MapRowsToObjects<T>(List<List<CellValue>> rows, List<Column> columns)
    {
        var result = new List<T>();
        var type = typeof(T);

        foreach (var row in rows)
        {
            var obj = Activator.CreateInstance<T>();

            for (var i = 0; i < columns.Count; i++)
            {
                var column = columns[i];
                if (column.Name == null) continue;
                var property = type.GetProperty(column.Name,
                    System.Reflection.BindingFlags.IgnoreCase |
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Instance);

                if (property == null || !property.CanWrite || i >= row.Count) continue;
                var cellValue = row[i];
                if (cellValue.Type == "null") continue;
                var value = ConvertCellValue(cellValue, property.PropertyType);
                property.SetValue(obj, value);
            }

            result.Add(obj);
        }

        return result;
    }

    private static object? ConvertCellValue(CellValue cellValue, Type targetType)
    {
        if (cellValue.Type == "null" || string.IsNullOrEmpty(cellValue.Value))
            return null;

        var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

        try
        {
            return cellValue.Type switch
            {
                "integer" or "float" => Convert.ChangeType(cellValue.Value, underlyingType),
                "text" when underlyingType == typeof(DateTime) => DateTime.Parse(cellValue.Value),
                "text" when underlyingType == typeof(bool) => Convert.ToBoolean(cellValue.Value),
                "text" => Convert.ChangeType(cellValue.Value, underlyingType),
                _ => cellValue.Value
            };
        }
        catch
        {
            return cellValue.Value;
        }
    }
}

// Clases para la respuesta del pipeline de Turso
public class TursoPipelineResponse
{
    [JsonProperty("baton")] public string? Baton { get; set; }

    [JsonProperty("base_url")] public string? BaseUrl { get; set; }
    [JsonProperty("results")] public List<TursoResult>? Results { get; set; }
}

public class TursoResult
{
    [JsonProperty("type")] public string? Type { get; set; } // "ok" o "error"

    [JsonProperty("response")] public TursoResponse? Response { get; set; }

    [JsonProperty("error")] public TursoError? Error { get; set; }
}

public class TursoResponse
{
    [JsonProperty("type")] public string? Type { get; set; } // "execute" o "query"

    [JsonProperty("result")] public TursoResultData? Result { get; set; }
}

public class TursoResultData
{
    [JsonProperty("cols")] public List<Column>? Columns { get; set; }

    [JsonProperty("rows")] public List<List<CellValue>>? Rows { get; set; }

    [JsonProperty("affected_row_count")] public int AffectedRowCount { get; set; }

    [JsonProperty("last_insert_rowid")] public string? LastInsertRowId { get; set; }

    [JsonProperty("replication_index")] public string? ReplicationIndex { get; set; }

    [JsonProperty("rows_read")] public int RowsRead { get; set; }

    [JsonProperty("rows_written")] public int RowsWritten { get; set; }

    [JsonProperty("query_duration_ms")] public double QueryDurationMs { get; set; }
}

public class Column
{
    [JsonProperty("name")] public string? Name { get; set; }

    [JsonProperty("decltype")] public string? DeclType { get; set; }
}

public class CellValue
{
    [JsonProperty("type")] public string? Type { get; set; } // "integer", "text", "float", "null"

    [JsonProperty("value")] public string? Value { get; set; }
}

public class TursoError
{
    [JsonProperty("message")] public string? Message { get; set; }

    [JsonProperty("code")] public string? Code { get; set; }
}