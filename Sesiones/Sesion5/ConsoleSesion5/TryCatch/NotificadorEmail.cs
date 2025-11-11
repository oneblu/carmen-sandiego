namespace ConsoleSesion3._4_Principio_Responsabilidad_Unica.Bien;

// Responsabilidad: Notificación
public class NotificadorEmail
{
    public void EnviarEmailBienvenida(string email)
    {
        Console.WriteLine($"Enviando email de bienvenida a {email}...");
        // Lógica real de envío de email aquí
    }
}