namespace ConsoleSesion3._1_1_Composicion;

public class Carro
{
    private Motor _motor; // Composición fuerte
    
    public string Modelo { get; set; }
    
    public Carro(string modelo, string tipoMotor, int caballosFuerza)
    {
        Modelo = modelo;
        // El carro CREA su propio motor
        _motor = new Motor(tipoMotor, caballosFuerza);
    }
    
    public void Encender()
    {
        Console.WriteLine($"Carro {Modelo} con motor {_motor.Tipo} encendido");
    }
    
    // Cuando el carro se destruye, el motor también
}
