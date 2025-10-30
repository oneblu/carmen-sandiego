namespace ConsoleSesion3._4_Principio_Responsabilidad_Unica.Bien;

// Responsabilidad: Persistencia
public class UsuarioRepository
{
    public void Guardar(string nombre, string email)
    {
        Console.WriteLine($"Guardando usuario {nombre} en BD...");
        // Lógica real de base de datos aquí
    }
}