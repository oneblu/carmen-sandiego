namespace Pinia.Application.Dtos
{
    public sealed class CuentaDto
    {
        public int Id { get; set; }
        public long Numero { get; set; }

        /// <summary>
        /// Ahorros o Corriente
        /// </summary>
        public string Tipo { get; set; }

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
}
