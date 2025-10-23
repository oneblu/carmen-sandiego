namespace ConsoleApp1.EjemploStaticMethod;

/// <summary>
/// OJO con este ejemplo
/// Esta clase no es static, pero puede contener metodos estaticos,
/// por lo tanto esta clase puede ser mixta,
/// es decir, la puedo instanciar y usar los metodos o propiedades que no son estaticos
/// o puede llamar a las propiedades y metodos que si son static
/// </summary>
public class ImpuestoIva
{
    public decimal CalcularIva19(decimal precio)
    {
        return (precio * 19) / 100;
    }

    /// <summary>
    /// Si la clase es static entonces todos los metodos debe ser static
    /// </summary>
    /// <param name="precio"></param>
    /// <param name="tasa"></param>
    /// <returns></returns>
    public static decimal CalcularIva(decimal precio, decimal tasa)
    {
        return (precio * tasa) / 100;
    }
}