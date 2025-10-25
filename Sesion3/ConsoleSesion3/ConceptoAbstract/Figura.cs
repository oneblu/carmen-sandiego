namespace ConsoleSesion3.ConceptoAbstract;

public abstract class Figura
{
    public double Lado { get; set; }
    public abstract double CalcularArea();
    public abstract void MostrarInformacion();
}