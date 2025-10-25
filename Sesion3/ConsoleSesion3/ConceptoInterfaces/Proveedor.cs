namespace ConsoleSesion3.ConceptoInterfaces;

public class Proveedor:IContacto
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
}