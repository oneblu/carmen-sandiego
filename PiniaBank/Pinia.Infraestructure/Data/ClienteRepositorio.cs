using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;

namespace Pinia.Infraestructure.Data;

public class ClienteRepositorio:IClienteRepositorio
{
    TursoClient _clientTurso;

    public ClienteRepositorio()
    {
        _clientTurso = new TursoClient("libsql://pinia-cangulor8.aws-us-east-1.turso.io","eyJhbGciOiJFZERTQSIsInR5cCI6IkpXVCJ9.eyJhIjoicnciLCJpYXQiOjE3NjIzMDY2OTcsImlkIjoiYTc1YjhjNzItNjBhMC00YTE1LWFkNjAtNTZlZWY2ZWY4MGRkIiwicmlkIjoiNGM4ZWM2ZDQtNjc4Yi00MzZhLTk4M2QtNjE4NWFhMTNkMTFjIn0.ORfMlLRAi8_pTTh03lwSZOmfSe3LIcuHzyFiqVkPI5D1mcVmnu42XM4l_ztoOJLMzKoYDN6sgV_g2NBwPlzkAA");
    }

    public void Crear(Cliente cliente)
    {
        var sql = $"INSERT INTO clientes(nombres, apellidos,numero_identificacion)" +
                  $"VALUES" +
                  $"('{cliente.Nombres}','{cliente.Apellidos}','{cliente.NumeroIdentificacion}');";
        var result = _clientTurso.ExecuteQuery(sql);
    }

    public void Actualizar(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void CambiarEstado(int idCLiente, bool estado)
    {
        throw new NotImplementedException();
    }

    public List<Cliente> ConsultarTodos()
    {
        string sql = "SELECT * FROM clientes;";
        string result = _clientTurso.ExecuteQuery(sql);

        return new List<Cliente>();
    }
}