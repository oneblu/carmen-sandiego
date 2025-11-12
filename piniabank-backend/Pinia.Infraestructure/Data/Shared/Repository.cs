using Npgsql;
using Dapper;

namespace Pinia.Infraestructure.Data.Shared
{
    public abstract class Repository
    {
        const string connectionString = "";
        protected static async Task<NpgsqlConnection> GetOpenConnectionAsync()
        {
            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        protected async Task<int> MyExecuteNonQueryAsync(string sql, Dictionary<string, object> parameter)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                await using var cmd = new NpgsqlCommand(sql, connection);

                foreach (var param in parameter)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                var result = await cmd.ExecuteNonQueryAsync();

                return result;
            }
        }

        protected async Task<IEnumerable<T>> MyQueryAsync<T>(string sql, Dictionary<string, object>? parameters = null)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                var result = await connection.QueryAsync<T>(sql, parameters);

                return result;
            }
        }
    }
}
