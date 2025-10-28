namespace ConsoleSesion3.ConceptoAbstract;

/// <summary>
/// Las clases abstractas solo se pueden heredar
/// </summary>
public abstract class Figura
{
    public double Lado { get; set; }

    public string GetNombre()
    {
        return this.GetType().Name;
    }

    public double CalcularPerimetro()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Cuando se usa en el metodo, entonces quien herede debe implementar este metodo
    /// </summary>
    /// <returns></returns>
    public abstract double CalcularArea();
    public abstract void MostrarInformacion();
}