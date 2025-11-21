using Dapper;
using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data.Shared;

namespace Pinia.Infraestructure.Data
{
    public sealed class TransaccionRepositorio : Repository, ITransaccionRepositorio
    {
        public async Task<bool> CancelarTransaccion(int id)
        {
            const string sql = "UPDATE public.transacciones SET estado = false WHERE id = @Id";
            var parameters = new Dictionary<string, object>
            {
                { "@Id", id }
            };
            var result = await MyExecuteNonQueryAsync(sql, parameters);
            return result > 0;
        }

        public async Task<IEnumerable<TransaccionBancaria>> ConsultarPorCuentaAsync(int idCuenta)
        {
            const string sql = "SELECT id, valor, id_cuenta AS idCuenta, fecha_de_creacion AS fechaDeCreacion, estado, tipo " +
                               "FROM public.transacciones WHERE id_cuenta = @IdCuenta";
            var parameters = new Dictionary<string, object>
            {
                { "@IdCuenta", idCuenta }
            };
            var result = await MyQueryAsync<TransaccionBancaria>(sql, parameters);
            return result;
        }

        public Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CrearAsync(TransaccionBancaria newTtransaccion)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        const string sql =
                            "INSERT INTO public.transacciones (id_cuenta, valor, tipo) VALUES (@IdCuenta, @Valor, @Tipo)";
                        var parameters = new Dictionary<string, object>
                        {
                            { "@IdCuenta", newTtransaccion.IdCuenta },
                            { "@Valor",Math.Abs(newTtransaccion.Valor) },
                            { "@Tipo", newTtransaccion.Tipo }
                        };

                        await connection.ExecuteAsync(sql, parameters, transaction);

                        const string sqlActualizarSaldo =
                            "UPDATE public.cuentas SET saldo = saldo + @Valor WHERE id = @IdCuenta";
                        var parametersActualizarSaldo = new Dictionary<string, object>
                        {
                            { "@IdCuenta", newTtransaccion.IdCuenta },
                            { "@Valor", newTtransaccion.Valor }
                        };

                        await connection.ExecuteAsync(sqlActualizarSaldo, parametersActualizarSaldo, transaction);

                        transaction.Commit();

                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }
    }
}