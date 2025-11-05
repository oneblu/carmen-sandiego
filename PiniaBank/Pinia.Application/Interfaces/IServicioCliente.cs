using Pinia.Application.Dtos;
using Pinia.Domain.Entidades;

namespace Pinia.Application.Interfaces;

public interface IServicioCliente
{
    Task<int> Crear(CrearClienteDto crearClienteDto);
    void Actualizar(Cliente cliente);
    void CambiarEstado(int idCLiente, bool estado);
    Task<List<ClienteDto>> ConsultarTodos();
}