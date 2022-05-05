using CadastroUsuarios.Dominio.Entidades;
using CadastroUsuarios.Inputs;
using CadastroUsuarios.Outputs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        static List<Usuario> usuarios;
        public UsuarioController()
        {
            if (usuarios == null)
                usuarios = new List<Usuario>();
        }

        [HttpPost()]
        public ActionResult CriarUsuario(UsuarioInput input)
        {
            var errorOutput = new ErrorOutput();
            if (string.IsNullOrEmpty(input.Senha))
                errorOutput.AddError("Senha é obrigatoria");

            if (string.IsNullOrEmpty(input.Login))
                errorOutput.AddError("Login é obrigatório");

            if (string.IsNullOrEmpty(input.Nome))
                errorOutput.AddError("Nome é obrigatório");

            if (errorOutput.HasErrors)
                return BadRequest(errorOutput);

            var usuario = new Usuario(input.Senha, input.Login, input.Nome);

            usuarios.Add(usuario);

            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public ActionResult GetUsuario(Guid id)
        {
            var usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpGet()]
        public ActionResult GetUsuarios()
        {
            if (usuarios == null || !usuarios.Any())
                return NoContent();

            return Ok(usuarios);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(Guid id)
        {
            var usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return NotFound();

            usuarios.Remove(usuario);

            return Ok();
        }
    }
}
