using Pinia.Application.Dtos;

namespace Pinia.Application.Interfaces
{
    public interface IServicioCuenta
    {
        Task<long> Crear(CrearCuentaDto cuenta);
        Task<bool> ActualizarSaldo(int idCuenta, decimal nuevoSaldo);
        Task<bool> CambiarEstado(int idCuenta, bool estado);
        Task<IEnumerable<CuentaDto>> ConsultarPorCliente(int idCliente);
    }
}
