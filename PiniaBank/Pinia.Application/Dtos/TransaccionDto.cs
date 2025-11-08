namespace Pinia.Application.Dtos
{
    public class TransaccionDto
    {
        /// <summary>
        /// Llave primaria o identificador de la transaccion
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Valor de la transaccion
        /// </summary>
        public double Valor { get; set; }

        /// <summary>
        /// Retiro o Consignacion
        /// </summary>
        public string Tipo { get; set; }

        public DateTime FechaDeCreacion { get; set; }
    }
}
