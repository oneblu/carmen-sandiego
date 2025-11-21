using Pinia.Application.Dtos;
using Pinia.Domain.Entidades;

namespace Pinia.Application.Interfaces
{
    public interface IServicioTransaccion
    {
        Task<bool> CrearAsync(CrearTransaccionDto transaccionDto);
        Task<IEnumerable<TransaccionBancaria>> ConsultarPorCuentaAsync(int idCuenta);

        Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta);

        Task<bool> CancelarTransaccion(int id);
    }
}
