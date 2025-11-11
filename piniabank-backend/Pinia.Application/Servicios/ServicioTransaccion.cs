using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data;

namespace Pinia.Application.Servicios
{
    public sealed class ServicioTransaccion : IServicioTransaccion
    {
        private readonly ITransaccionRepositorio _transaccionRepositorio = new TransaccionRepositorio();
        public async Task<bool> CancelarTransaccion(int id)
        {
            return await _transaccionRepositorio.CancelarTransaccion(id);
        }

        public Task<IEnumerable<TransaccionDto>> ConsultarPorCuentaAsync(int idCuenta)
        {
            throw new NotImplementedException();
        }

        public Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta)
        {
            throw new NotImplementedException();
        }

        public Task<int> CrearAsync(CrearTransaccionDto transaccionDto)
        {
            throw new NotImplementedException();
        }
    }
}
