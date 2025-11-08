using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data.Shared;

namespace Pinia.Infraestructure.Data
{
    public sealed class TransaccionRepositorio : Repository, ITransaccionRepositorio
    {
        public async Task<bool> CancelarTransaccion(int id)
        {
            const string sql = "UPDATE transacciones SET estado = false WHERE id = @Id";
            var parameters = new Dictionary<string, object>
            {
                { "@Id", id }
            };
            var result = await MyExecuteNonQueryAsync(sql, parameters);
            return result > 0;
        }

        public Task<IEnumerable<Transaccion>> ConsultarPorCuentaAsync(int idCuenta)
        {
            throw new NotImplementedException();
        }

        public Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta)
        {
            throw new NotImplementedException();
        }

        public Task<int> CrearAsync(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }
    }
}
