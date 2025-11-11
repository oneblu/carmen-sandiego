namespace ConsoleSesion3._3_1_Sin_Dependencias_Inyeccion_Acoplado;

public class UsuarioService
{
    private EmailService _emailService; // Dependencia concreta
    
    public UsuarioService()
    {
        _emailService = new EmailService(); // Creación interna - alto acoplamiento
    }
    
    public void RegistrarUsuario(string nombre)
    {
        Console.WriteLine($"Registrando usuario: {nombre}");
        _emailService.EnviarEmail($"Bienvenido {nombre}");
    }
}