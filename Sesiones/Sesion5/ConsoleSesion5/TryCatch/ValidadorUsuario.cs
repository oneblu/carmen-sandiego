namespace ConsoleSesion3._4_Principio_Responsabilidad_Unica.Bien;

// CORRECTO: Cada clase tiene una única responsabilidad

// Responsabilidad: Validación
public class ValidadorUsuario
{
    public bool Validar(string nombre, string email)
    {
        if (string.IsNullOrEmpty(nombre))
            throw new ArgumentException("Nombre es invalido");
        
        if (!email.Contains("@"))
            throw new Exception("Email es invalido");
            
        return true;
    }
}





