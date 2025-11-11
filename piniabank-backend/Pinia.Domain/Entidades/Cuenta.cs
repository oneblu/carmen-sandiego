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

    /// <summary>
    /// Cuanta plata hay en la cuenta
    /// </summary>
    public decimal Saldo { get; set; }

    /// <summary>
    /// True Activa, False Inactiva
    /// </summary>
    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }
}