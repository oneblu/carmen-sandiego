namespace ConsoleSesion3.ConceptoAbstract;

public class Triangulo : Figura
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public Triangulo(double baseTri, double altura)
    {
        Base = baseTri;
        Altura = altura;
    }

    public override double CalcularArea()
    {
        return (Base * Altura) / 2;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine($"Triángulo - Base: {Base}, Altura: {Altura}, Área: {CalcularArea():F2}");
    }
}