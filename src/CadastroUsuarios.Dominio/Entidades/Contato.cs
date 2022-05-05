using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuarios.Dominio.Entidades
{
    public class Contato : Entidade
    {
        public Contato(string nome, string url) : base()
        {
            Nome = nome;
            Url = url;
        }

        public string Nome { get; private set; }
        public string Url { get; private set; }
    }
}
