namespace ConsoleSesion3._4_Principio_Responsabilidad_Unica.Bien;

// CORRECTO: Cada clase tiene una única responsabilidad

// Responsabilidad: Validación
public class ValidadorUsuario
{
    public bool Validar(string nombre, string email)
    {
        if (string.IsNullOrEmpty(nombre))
            return false;
        
        if (!email.Contains("@"))
            return false;
            
        return true;
    }
}





