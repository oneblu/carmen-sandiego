namespace ConsoleSesion3.ConceptoAbstract;

public class CuadradoVirtual
{
    public double Lado { get; set; }
    public CuadradoVirtual(double lado)
    {
        Lado = lado;
    }
    

    public virtual double CalcularArea()
    {
        return Lado * Lado;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Cuadrado padre - Lado: {Lado}, Área: {CalcularArea():F2}");
    }
}