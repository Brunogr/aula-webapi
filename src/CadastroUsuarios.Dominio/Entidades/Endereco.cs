using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuarios.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        public Endereco(string cep, string logradouro) : base()
        {
            Cep = cep;
            Logradouro = logradouro;
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
    }
}
