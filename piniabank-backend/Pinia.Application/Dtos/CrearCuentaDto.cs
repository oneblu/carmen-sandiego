using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinia.Application.Dtos
{
    public sealed class CrearCuentaDto
    {
        /// <summary>
        /// Ahorros o Corriente
        /// </summary>
        public string Tipo { get; set; }

        public int IdCliente { get; set; }
    }
}
