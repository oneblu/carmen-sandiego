namespace ConsoleSesion3.ConceptoAbstract;

public class Rectangulo : Figura
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public Rectangulo(double baseRect, double altura)
    {
        Base = baseRect;
        Altura = altura;
    }

    public override double CalcularArea()
    {
        return Base * Altura;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine($"Rectángulo - Base: {Base}, Altura: {Altura}, Área: {CalcularArea():F2}");
    }
}