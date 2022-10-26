using Microsoft.AspNetCore.Mvc;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;

namespace ProjetoUsuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuario;

        public UsuarioController(IUsuarioService usuario)
        {
            _usuario = usuario;
        }

        [HttpGet]
        public IActionResult BuscarTodosUsuarios()
        {
            var usuarios = _usuario.BuscarTodosUsuarios();
            if(usuarios is null) return NotFound("Nenhum usuario encotrado"); 
            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId/{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            var usuario = _usuario.BuscarUsuarioId(id);
            if (usuario is null) return NotFound("Usuário não encontrado!");
            return Ok(usuario);
        }

        [HttpPost("CriarUsuario")]
        public IActionResult CriarUsuario([FromBody] UsuarioDTO usuario)
        {
            if(usuario is null) return BadRequest();
            var usuarioCriado = _usuario.CriarUsuario(usuario);
            if(usuarioCriado is null) return BadRequest("usuário existente");
            return Ok(usuario);
        }

        //Felipe
        [HttpPost("criar-usuario-com-mesa")]
        public IActionResult CriarUsuarioComMesa([FromBody] UsuarioDTO usuario)
        {
            if(usuario is null) return BadRequest();
            var usuarioCriado = _usuario.CriarUsuario(usuario);
            if(usuarioCriado is null) return BadRequest("usuário existente");
            return Ok(usuario);
        }

        [HttpPut("AtualizarUsuario")]
        public IActionResult AtualizarUsuario([FromForm] UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO is null) return BadRequest();
            var usuarioAtualizado = _usuario.AtualizarUsuario(usuarioDTO);
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("DesativarUsuario/{id}")]
        public IActionResult DesativarUsuario(int id)
        {
            _usuario.DesativarUsuario(id);
            return NoContent();
        }
    }
}