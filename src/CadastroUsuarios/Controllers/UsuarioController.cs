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

        /// <summary>
        /// Método para CRIAR usuário
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// método para retornar TODOS os usuários
        /// </summary>
        /// <returns></returns>
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
                return NoContent();

            usuarios.Remove(usuario);

            return Ok();
        }

        /// <summary>
        /// método para adicionar contato do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contato"></param>
        /// <returns></returns>
        [HttpPost("{id}/contato")]
        public ActionResult CadastrarContatoUsuario(Guid id, [FromBody]ContatoInput contato)
        {
            var usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return NoContent();

            usuario.AdicionarContato(new Contato(contato.Nome, contato.Uri));

            return Ok(usuario);
        }

        /// <summary>
        /// método para deletar contato do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idContato"></param>
        /// <returns></returns>
        [HttpDelete("{id}/contato/{idContato}")]
        public ActionResult DeletarContatoUsuario(Guid id, Guid idContato)
        {
            var usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return NoContent();

            var contato = usuario.Contatos.FirstOrDefault(contato => contato.Id == idContato);

            if (contato == null)
                return NoContent();

            usuario.RemoverContato(contato);

            return Ok(usuario);
        }
        /// <summary>
        /// método para criar endereço para o usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contato"></param>
        /// <returns></returns>
        [HttpPost("{id}/endereco")]
        public ActionResult CadastrarEnderecoUsuario(Guid id, [FromBody] EnderecoInput contato)
        {
            var usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return NotFound();

            usuario.AdicionarEndereco(new Endereco(contato.Cep, contato.Logradouro));

            return Ok(usuario);
        }

        /// <summary>
        /// Método para deletar endereço do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idEndereco"></param>
        /// <returns></returns>
        [HttpDelete("{id}/endereco/{idEndereco}")]
        public ActionResult DeletarEnderecoUsuario(Guid id, Guid idEndereco)
        {
            var usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return NoContent();

            var endereco = usuario.Enderecos.FirstOrDefault(endereco => endereco.Id == idEndereco);

            if (endereco == null)
                return NoContent();

            usuario.RemoverEndereco(endereco);

            return Ok(usuario);
        }
    }
}
