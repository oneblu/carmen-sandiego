using Npgsql;

namespace Pinia.Infraestructure.Data.Shared
{
    public abstract class Repository
    {
        const string connectionString = "Server=ep-nameless-cell-a4p1pw8y-pooler.us-east-1.aws.neon.tech;Port=5432;Database=neondb;User Id=neondb_owner;Password=npg_KWRvybNDh1w8;";

        protected static async Task<NpgsqlConnection> GetOpenConnectionAsync()
        {
            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        protected async Task<int> ExecuteNonQueryAsync(string sql, Dictionary<string, object> parameter)
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
    }
}
