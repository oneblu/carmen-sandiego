using ConsoleSesion3.ConceptoInterfaces.Database;

namespace ConsoleSesion3.ConceptoInterfaces;

public class DbContacto: IDbContacto
{
    public bool CrearCliente(IContacto contacto)
    {
       /* Simulo que guardo en una db
        
        */
       return true;
    }

    public bool ActualizarCliente(int idCliente, IContacto contacto)
    {
        throw new NotImplementedException();
    }

    public bool EliminarCliente(int idContacto)
    {
        throw new NotImplementedException();
    }
}