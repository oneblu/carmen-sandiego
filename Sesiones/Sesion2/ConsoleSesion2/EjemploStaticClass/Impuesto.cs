namespace ConsoleApp1.EjemploStaticClass;


/// <summary>
/// static: Esta clase no se puede heredar ni instanciar,
/// esta se auto instancia 1 sola vez cuando se ejecuta el programa
/// lo que quiere decir es que solo va a existir 1 sola vez en memoria
/// </summary>
public static class Impuesto
{
    /// <summary>
    /// Si la clase es static entonces todos los metodos debe ser static
    /// </summary>
    /// <param name="precio"></param>
    /// <param name="tasa"></param>
    /// <returns></returns>
    public static decimal Calcular(decimal precio, decimal tasa)
    {
        return (precio * tasa)/100;
    }
}