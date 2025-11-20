using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data.Shared;

namespace Pinia.Infraestructure.Data
{
    public sealed class CuentaRepositorio : Repository, ICuentaRepositorio
    {
        public async Task<int> Crear(Cuenta cuenta)
        {
            var sql = "INSERT INTO public.cuentas (numero, tipo, id_cliente) " +
            "VALUES (@Numero, @Tipo, @IdCliente)";

            var parameters = new Dictionary<string, object>
        {
            { "@Numero", cuenta.Numero },
            { "@Tipo", cuenta.Tipo },
            { "@IdCliente", cuenta.IdCliente }
        };

            var result = await MyExecuteNonQueryAsync(sql, parameters);

            return result;
        }

        public async Task<bool> ActualizarSaldo(int id, decimal nuevoMonto)
        {
            var sql = "UPDATE public.cuentas SET saldo = saldo + @NuevoMonto WHERE id = @Id";
            var parameters = new Dictionary<string, object> {
                { "@Id", id },
                { "@NuevoMonto", nuevoMonto }
            };

            var rowsAffected = await MyExecuteNonQueryAsync(sql, parameters);

            return rowsAffected > 0;
        }

        public async Task<bool> CambiarEstado(int id, bool estado)
        {
            var sql = "UPDATE public.cuentas SET estado = @Estado WHERE id = @Id";
            var parameters = new Dictionary<string, object> {
                { "@Id", id },
                { "@Estado", estado }
            };

            var rowsAffected = await MyExecuteNonQueryAsync(sql, parameters);

            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Cuenta>> ConsultarPorCliente(int idCliente)
        {

            const string sql = "SELECT * FROM public.cuentas WHERE id_cliente = @IdCliente";
            var parameters = new Dictionary<string, object>
                {
                    { "@IdCliente", idCliente }
                };

            var cuentas = await MyQueryAsync<Cuenta>(sql, parameters);

            return cuentas;

        }
    }
}
