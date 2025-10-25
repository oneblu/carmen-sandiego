namespace ConsoleSesion3.ConceptoAbstract;

public class Circulo: Figura
{
    private double Radio { get; set; }
    
    public Circulo(double radio)
    {
        Radio = radio;
    }
    
    public override double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }
    
    public override void MostrarInformacion()
    {
        Console.WriteLine($"Círculo - Radio: {Radio}, Área: {CalcularArea():F2}");
    }
   
}