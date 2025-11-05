namespace Pinia.Domain.Entidades;

public class Transaccion
{
    /// <summary>
    /// Llave primaria o identificador de la transaccion
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Valor de la transaccion
    /// </summary>
    public double Monto { get; set; }
    
    /// <summary>
    /// Identifico al cliente
    /// </summary>
    public int IdCliente { get; set; }
    
    /// <summary>
    /// Identifico la cuenta
    /// </summary>
    public int IdCuenta { get; set; }
    
    /// <summary>
    /// Retiro o Consignacion
    /// </summary>
    public string Tipo { get; set; }
    
    public DateTime Fecha { get; set; }
}