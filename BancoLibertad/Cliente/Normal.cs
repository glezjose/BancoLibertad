using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLibertad.Cliente
{
    public class Normal: Cliente
    {
        /// <summary>
        /// ID del cliente (Trabajador)
        /// </summary>
        public int iIdClienteNormal { get; set; }

        /// <summary>
        /// Nombre de la empresa donde trabaja el cliente (Trabajador)
        /// </summary>
        public string cEmpresa { get; set; }

    }
}
