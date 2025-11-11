namespace ConsoleSesion3._3_2_Con_Inyeccion_Dependencias_Desacoplado;

public class EmailService : INotificacionService
{
    public void EnviarNotificacion(string mensaje)
    {
        Console.WriteLine($"Email enviado: {mensaje}");
    }
}