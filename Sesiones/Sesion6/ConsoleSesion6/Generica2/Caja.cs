namespace ConsoleSesion3.Generica2;
public class Caja<T>
{
    private T _contenido;

    public Caja(T item)
    {
        _contenido = item;
    }

    public T ObtenerContenido()
    {
        return _contenido;
    }

    public void MostrarTipo()
    {
        Console.WriteLine($"Tipo de Contenido: {_contenido.GetType().Name}");
    }
}