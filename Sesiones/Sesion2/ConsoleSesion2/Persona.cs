namespace ConsoleApp1;

/// <summary>
/// Esta es la clase base de donde van a heredar las clases Estudiante y Profesor
/// </summary>
public class Persona
{
    /// <summary>
    /// Estas son propiedades porque ya tienen un getter (get) y un setter (set)
    /// </summary>
    public string Nombre { get; set; }

    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    /// <summary>
    /// Este es una atributo calculado porque se basa en otros parametros, este es de solo lectura
    /// </summary>
    public string NombreCompleto => $"{Nombre} {Apellido}";

    public Persona()
    {
    }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }

    public Persona(string nombre, string apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
    }

    public Persona(string nombre, string apellido, string email, string telefono)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }

    /*
     * CamelCase : C#
     * snake_case : mysql o postgres
     * kebap-case : apis rest full
     */
}