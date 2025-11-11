namespace ConsoleSesion3._3_2_Con_Inyeccion_Dependencias_Desacoplado;

// Contenedor de Inyeccion de Dependencia simple
public class DependencyInjectionContainer
{
    public static INotificacionService GetNotificacionService()
    {
        // Aquí podríamos cambiar fácilmente la implementación
        return new EmailService();
        //  return new SMSService();
    }
}
