using Pinia.Domain.Entidades;

namespace Pinia.Domain.Interfaces.Repositorios;

public interface ICuentaRepositorio
{
    Task<int> Crear(Cuenta cuenta);
    Task<bool> ActualizarSaldo(int idCuenta, decimal nuevoSaldo);
    Task<bool> CambiarEstado(int idCuenta, bool estado);
    
    Task<IEnumerable<Cuenta>> ConsultarPorCliente(int idCliente);
}