using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLibertad.Cliente
{
    public class Universitario: Cliente
    {
        /// <summary>
        /// ID del cliente universitario (Estudiante)
        /// </summary>
        public int iIdClienteUniversitario { get; set; }

        /// <summary>
        /// Nombre del instituto donde estudia el cliente universitario (Estudiante)
        /// </summary>
        public string cInstituto { get; set; }

        /// <summary>
        /// Nombre del tutor (Padre o Madre) del cliente universitario (Estudiante)
        /// </summary>
        public string cNombreTutor { get; set; }
    }
}
