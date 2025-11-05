namespace Pinia.Domain.Entidades;

public class Cuenta
{
    public int Id { get; set; }
    public long Numero { get; set; }
    
    /// <summary>
    /// Ahorros o Corriente
    /// </summary>
    public string Tipo { get; set; }
    
    public int IdCliente { get; set; }
}