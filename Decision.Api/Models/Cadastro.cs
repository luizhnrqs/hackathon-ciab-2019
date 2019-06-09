using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decision.Api.Models
{
    public class Cadastro
    {
        public string Nome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public DateTime DtNascimento { get; set; }

        public string NomeMae { get; set; }

        public DateTime Validade { get; set; }
    }
}