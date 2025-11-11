using Pinia.Domain.Entidades;

namespace Pinia.Domain.Interfaces.Repositorios;

public interface IClienteRepositorio
{
    Task<int> Crear(Cliente cliente);
    void Actualizar(Cliente cliente);
    void CambiarEstado(int idCLiente, bool estado);
    
    Task<IEnumerable<Cliente>> ConsultarTodos();
}