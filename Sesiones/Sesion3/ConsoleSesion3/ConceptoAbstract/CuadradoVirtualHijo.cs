namespace ConsoleSesion3.ConceptoAbstract;

public class CuadradoVirtualHijo : CuadradoVirtual
{
    public CuadradoVirtualHijo(double lado) : base(lado)
    {
    }

    public new void MostrarInformacion()
    {
        Console.WriteLine($"Cuadrado hijo - Lado: {Lado}, Área: {CalcularArea():F2}");
    }
}