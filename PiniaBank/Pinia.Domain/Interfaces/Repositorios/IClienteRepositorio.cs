using Pinia.Domain.Entidades;

namespace Pinia.Domain.Interfaces.Repositorios;

public interface IClienteRepositorio
{
    void Crear(Cliente cliente);
    void Actualizar(Cliente cliente);
    void CambiarEstado(int idCLiente, bool estado);
    
    List<Cliente> ConsultarTodos();
}