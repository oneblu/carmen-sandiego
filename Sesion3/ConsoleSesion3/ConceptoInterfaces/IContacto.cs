namespace ConsoleSesion3.ConceptoInterfaces;

public interface IContacto
{
    string Nombre { get; set; }
    string Apellido { get; set; }
    string Correo { get; set; }
    string Telefono { get; set; }

    string NombreCompleto();
}