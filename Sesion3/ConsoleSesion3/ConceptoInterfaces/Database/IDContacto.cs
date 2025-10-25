namespace ConsoleSesion3.ConceptoInterfaces.Database;

public interface IDbContacto
{
    bool CrearCliente(IContacto contacto);
    bool ActualizarCliente(int idCliente, IContacto contacto);
    bool EliminarCliente(int idContacto);
}