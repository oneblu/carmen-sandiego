using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data.Shared;

namespace Pinia.Infraestructure.Data;

public class ClienteRepositorio : Repository, IClienteRepositorio
{
    public async Task<int> Crear(Cliente cliente)
    {
        var sql = "INSERT INTO carlos.clientes (nombres, apellidos, numero_identificacion) " +
        "VALUES (@Nombres, @Apellidos, @NumeroIdentificacion)";

        var parameters = new Dictionary<string, object>
        {
            { "@Nombres", cliente.Nombres },
            { "@Apellidos", cliente.Apellidos },
            { "@NumeroIdentificacion", cliente.NumeroIdentificacion ?? (object)DBNull.Value }
        };

        var result = await MyExecuteNonQueryAsync(sql, parameters);

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

    public async Task<IEnumerable<Cliente>> ConsultarTodos()
    {
        var sql = "SELECT * FROM carlos.clientes";
        var clientes = await MyQueryAsync<Cliente>(sql);
        return clientes;
    }
}