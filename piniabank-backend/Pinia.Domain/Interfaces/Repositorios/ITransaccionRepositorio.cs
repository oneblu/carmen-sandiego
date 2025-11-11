using Pinia.Domain.Entidades;


namespace Pinia.Domain.Interfaces.Repositorios
{
    public interface ITransaccionRepositorio
    {
        Task<int> CrearAsync(Transaccion transaccion);
        Task<IEnumerable<Transaccion>> ConsultarPorCuentaAsync(int idCuenta);

        Task<double> ConsultarSaldoPorCuentaAsync(int idCuenta);

        Task<bool> CancelarTransaccion(int id);
    }
}
