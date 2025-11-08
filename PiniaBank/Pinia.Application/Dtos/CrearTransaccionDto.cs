namespace Pinia.Application.Dtos
{
    public sealed class CrearTransaccionDto
    {

        /// <summary>
        /// Valor de la transaccion
        /// </summary>
        public double Valor { get; set; }

        /// <summary>
        /// Identifico la cuenta
        /// </summary>
        public int IdCuenta { get; set; }

        /// <summary>
        /// Retiro o Consignacion
        /// </summary>
        public string Tipo { get; set; }
    }
}
