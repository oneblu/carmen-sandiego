namespace ConsoleSesion3._4_Principio_Responsabilidad_Unica.Mal;

// Violación del SRP
// MAL: Una clase con múltiples responsabilidades
public class UsuarioManager
{
    public void RegistrarUsuario(string nombre, string email)
    {
        // Responsabilidad 1: Validación
        if (string.IsNullOrEmpty(nombre))
            throw new ArgumentException("Nombre requerido");
        
        if (!email.Contains("@"))
            throw new ArgumentException("Email inválido");
        
        // Responsabilidad 2: Lógica de negocio
        Console.WriteLine($"Usuario {nombre} registrado");
        
        // Responsabilidad 3: Persistencia
        GuardarEnBaseDeDatos(nombre, email);
        
        // Responsabilidad 4: Notificación
        EnviarEmailBienvenida(email);
    }
    
    private void GuardarEnBaseDeDatos(string nombre, string email)
    {
        Console.WriteLine($"Guardando {nombre} en BD...");
    }
    
    private void EnviarEmailBienvenida(string email)
    {
        Console.WriteLine($"Enviando email a {email}...");
    }
}