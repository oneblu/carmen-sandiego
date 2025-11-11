namespace ConsoleSesion3._3_2_Con_Inyeccion_Dependencias_Desacoplado;

public class UsuarioService
{
    private readonly INotificacionService _notificacionService;
    
    // Inyección por constructor
    public UsuarioService(INotificacionService notificacionService)
    {
        _notificacionService = notificacionService;
    }
    
    public void RegistrarUsuario(string nombre)
    {
        Console.WriteLine($"Registrando usuario: {nombre}");
        _notificacionService.EnviarNotificacion($"{nombre}");
    }
}
