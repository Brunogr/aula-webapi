using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuarios.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        private string senha { get; set; }
        public Usuario(string senha, string login, string nome) : base()
        {
            this.senha = senha;
            Login = login;
            Nome = nome;
            Contatos = new List<Contato>();
            Enderecos = new List<Endereco>();
        }

        public string Login { get; private set; }
        public string Nome { get; private set; }        
        public List<Contato> Contatos { get; private set; }
        public List<Endereco> Enderecos { get; private set; }

        public Usuario AdicionarContato(Contato contato)
        {
            Contatos.Add(contato);
            return this;
        }

        public Usuario RemoverContato(Contato contato)
        {
            Contatos.Remove(contato);
            return this;
        }

        public Usuario AdicionarEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);
            return this;
        }

        public Usuario RemoverEndereco(Endereco endereco)
        {
            Enderecos.Remove(endereco);
            return this;
        }
    }
}
