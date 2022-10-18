using Microsoft.AspNetCore.Mvc;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;

namespace ProjetoUsuario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var usuarios = _usuario.FindAllUsuario();
            if(usuarios is null) return NotFound("Nenhum usuario encotrado"); 
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            var usuario = _usuario.FindById(id);
            if (usuario is null) return NotFound("Usuário não encontrado!");
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] UsuarioDTO usuario)
        {
            if(usuario is null) return BadRequest();
            var usuarioCriado = _usuario.Create(usuario);
            if(usuarioCriado is null) return BadRequest("usuário existente");
            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult AtualizarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO is null) return BadRequest();
            var usuarioAtualizado = _usuario.UpdateUsuario(usuarioDTO);
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult DesativarUsuario(int id)
        {
            _usuario.DeleteUsuario(id);
            return NoContent();
        }
    }
}