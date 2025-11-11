namespace ConsoleSesion3._3_2_Con_Inyeccion_Dependencias_Desacoplado;

public class SMSService : INotificacionService
{
    public void EnviarNotificacion(string mensaje)
    {
        Console.WriteLine($"SMS enviado: {mensaje}");
    }
}