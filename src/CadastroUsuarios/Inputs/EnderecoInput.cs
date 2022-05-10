using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuarios.Inputs
{
    /// <summary>
    /// Input para cadastro de endereço
    /// </summary>
    public class EnderecoInput
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
    }
}
