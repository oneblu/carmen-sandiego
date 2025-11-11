namespace ConsoleSesion3.Generica;


public interface IRepositorio<T>
{
    T ObtenerPorId(int id);
    List<T> ObtenerTodos();
    void Agregar(T entidad);
    void Actualizar(T entidad);
}