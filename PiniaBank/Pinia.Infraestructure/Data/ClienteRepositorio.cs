using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;

namespace Pinia.Infraestructure.Data;

public class ClienteRepositorio:Repository,IClienteRepositorio
{
   
    public async Task<int> Crear(Cliente cliente)
    {
        var sql = @"INSERT INTO clientes (nombres, apellidos, numero_identificacion) 
                VALUES ($nombres, $apellidos, $numero_identificacion)";

        var parameters = new Dictionary<string, object>
        {
            ["$nombres"] = cliente.Nombres,
            ["$apellidos"] = cliente.Apellidos,
            ["$numero_identificacion"] = cliente.NumeroIdentificacion,
        };

        var rowsAffected = await ExecuteAsync(sql, parameters);
        return rowsAffected;
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
        const string sql = "SELECT * FROM clientes;";
        var result =await QueryAsync<Cliente>(sql);

        return result;
    }
}