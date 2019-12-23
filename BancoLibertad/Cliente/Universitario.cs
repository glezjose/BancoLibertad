using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLibertad.Cliente
{
    public class Universitario: Cliente
    {
        public int iIdClienteUniversitario { get; set; }
        public string cInstituto { get; set; }
        public string cNombreTutor { get; set; }
    }
}
