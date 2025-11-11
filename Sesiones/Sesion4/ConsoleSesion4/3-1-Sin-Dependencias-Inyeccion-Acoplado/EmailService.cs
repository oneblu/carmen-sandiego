namespace ConsoleSesion3._3_1_Sin_Dependencias_Inyeccion_Acoplado;

public class EmailService
{
    public void EnviarEmail(string mensaje)
    {
        Console.WriteLine($"Enviando email: {mensaje}");
    }
}