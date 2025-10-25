namespace ConsoleSesion3.ConceptoAbstract;

public class CuadradoVirtual
{
    public double Lado { get; set; }
    
    public virtual double CalcularArea()
    {
        return Lado * Lado;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Rectángulo - Lado: {Lado}, Área: {CalcularArea():F2}");
    }
}