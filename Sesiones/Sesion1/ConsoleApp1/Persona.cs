namespace ConsoleApp1;

/// <summary>
/// Las clases siempre se nombran con la primera letra en mayuscula con nomenclatura CamelCase
/// </summary>
public class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public string NombreCompleto => $"{Nombre} {Apellido}";

    /*
     * Los parametros de los constructores siempre inician con una letra minuscula y con nomenclatura camelCase
     */
    
    /// <summary>
    /// Constructor en blanco
    /// </summary>
    public Persona()
    {
    }

    /// <summary>
    /// Constructor con 1 parametro
    /// </summary>
    /// <param name="nombre"></param>
    public Persona(string nombre)
    {
        Nombre = nombre;
    }

    /// <summary>
    /// Constructor con 2 parametros
    /// </summary>
    /// <param name="nombre"></param>
    /// <param name="apellido"></param>
    public Persona(string nombre, string apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
    }

    /// <summary>
    /// Constructor con 4 parametros
    /// </summary>
    /// <param name="nombre"></param>
    /// <param name="apellido"></param>
    /// <param name="email"></param>
    /// <param name="telefono"></param>
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