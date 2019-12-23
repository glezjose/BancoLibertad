using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLibertad.Cliente
{
    public class Cliente
    {
        /// <summary>
        /// NIP de la cuenta del cliente universitario y cliente trabajador 
        /// </summary>
        public int iNIP { get; set; }

        /// <summary>
        /// Nombre del cliente universitario y cliente trabajador
        /// </summary>
        public string cNombre { get; set; }

        /// <summary>
        /// Apellido del cliente universitario y cliente trabajador
        /// </summary>
        public string cApellido { get; set; }

        /// <summary>
        /// Saldo del cliente universitario y cliente trabajador
        /// </summary>
        public decimal dSaldo { get; set; }

    }
}
