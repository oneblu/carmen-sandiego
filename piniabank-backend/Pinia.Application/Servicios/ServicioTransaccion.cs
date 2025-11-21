using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Domain.Entidades;
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

        public async Task<IEnumerable<TransaccionBancaria>> ConsultarPorCuentaAsync(int idCuenta)
        {
            return await _transaccionRepositorio.ConsultarPorCuentaAsync(idCuenta);
        }

        public Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CrearAsync(CrearTransaccionDto transaccionDto)
        {
            if (transaccionDto.Valor <= 0)
            {
                throw new ArgumentException("Valor incorrecto");
            }

            var transaccion = new TransaccionBancaria
            {
                IdCuenta = transaccionDto.IdCuenta,
                Valor = transaccionDto.Tipo == "Retiro" ? transaccionDto.Valor * -1 : transaccionDto.Valor,
                Tipo = transaccionDto.Tipo
            };

            return await _transaccionRepositorio.CrearAsync(transaccion);
        }
    }
}