using Pinia.Domain.Entidades;


namespace Pinia.Domain.Interfaces.Repositorios
{
    public interface ITransaccionRepositorio
    {
        Task<bool> CrearAsync(TransaccionBancaria transaccionBancaria);
        Task<IEnumerable<TransaccionBancaria>> ConsultarPorCuentaAsync(int idCuenta);

        Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta);

        Task<bool> CancelarTransaccion(int id);
    }
}
