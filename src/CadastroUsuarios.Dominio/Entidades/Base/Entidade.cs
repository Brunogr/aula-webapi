using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuarios.Dominio.Entidades
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
