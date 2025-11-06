using Npgsql;
using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data.Shared;

namespace Pinia.Infraestructure.Data;

public class ClienteRepositorio : Repository, IClienteRepositorio
{
    public async Task<int> Crear(Cliente cliente)
    {
        var sql = "INSERT INTO clientes (nombres, apellidos, numero_identificacion) " +
        "VALUES (@Nombres, @Apellidos, @NumeroIdentificacion)";

        var parameters = new Dictionary<string, object>
        {
            { "@Nombres", cliente.Nombres },
            { "@Apellidos", cliente.Apellidos },
            { "@NumeroIdentificacion", cliente.NumeroIdentificacion ?? (object)DBNull.Value }
        };

        var result = await ExecuteNonQueryAsync(sql, parameters);

        return result;
    }

    public void Actualizar(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void CambiarEstado(int idCLiente, bool estado)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Cliente>> ConsultarTodos()
    {
        var listaClientes = new List<Cliente>();
        using (var connection =await GetOpenConnectionAsync())
        {
            await using var cmd = new NpgsqlCommand("SELECT * FROM clientes", connection);

            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var cliente = new Cliente
                {
                    Id = reader.GetInt32(0),
                    Nombres = reader.GetString(1),
                    Apellidos = reader.GetString(2),
                    NumeroIdentificacion = reader.IsDBNull(3) ? null : reader.GetString(3),
                    //FechaNacimiento = reader.GetDateTime(4),
                    //Telefono = reader.GetString(5),
                    //Email = reader.GetString(6),
                    //Sexo = reader.GetChar(7),
                    //Direccion = reader.GetString(8),
                    //Ciudad = reader.GetString(9),
                    //Estado = reader.GetBoolean(10)
                };
                listaClientes.Add(cliente);
            }

            return listaClientes;
        }
    }
}