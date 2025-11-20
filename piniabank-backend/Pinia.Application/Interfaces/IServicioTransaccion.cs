using Pinia.Application.Dtos;

namespace Pinia.Application.Interfaces
{
    public interface IServicioTransaccion
    {
        Task<bool> CrearAsync(CrearTransaccionDto transaccionDto);
        Task<IEnumerable<TransaccionDto>> ConsultarPorCuentaAsync(int idCuenta);

        Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta);

        Task<bool> CancelarTransaccion(int id);
    }
}
