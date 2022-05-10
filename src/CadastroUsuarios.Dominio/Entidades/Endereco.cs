using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuarios.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        public Endereco(string cep, string logradouro) : base()
        {
            if (!ValidarCep(cep))
                throw new Exception("Cep Invalido");

            Cep = cep;
            Logradouro = logradouro;
        }

        private bool ValidarCep(string cep)
        {
            bool valid = true;

            if (cep.Length != 9)
                valid = false;

            int count = 0;
            foreach (var digito in cep)
            {
                if (!char.IsNumber(digito) && count != 5)
                    valid = false;

                if (count == 5 && digito != '-')
                    valid = false;

                count++;
            }

            return valid;
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
    }
}
