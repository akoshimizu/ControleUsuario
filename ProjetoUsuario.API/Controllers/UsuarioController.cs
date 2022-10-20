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

        [HttpGet("BuscarMesasDoUsuario/{id}")]
        public IActionResult BuscarMesasDoUsuario(int id)
        {
            var mesasDoUsuario = _usuario.BuscarMesasDoUsuario(id);
            return Ok(mesasDoUsuario);
        }

        [HttpPost("CriarUsuario")]
        public IActionResult CriarUsuario([FromBody] UsuarioDTO usuario)
        {
            if(usuario is null) return BadRequest();
            var usuarioCriado = _usuario.CriarUsuario(usuario);
            if(usuarioCriado is null) return BadRequest("usuário existente");
            return Ok(usuario);
        }

        [HttpPut("AtualizarUsuario")]
        public IActionResult AtualizarUsuario([FromBody] UsuarioDTO usuarioDTO)
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

        [HttpPut("AdicionarMesa")]
        public IActionResult AdicionarMesa([FromQuery] int id, MesaDTO mesa)
        {
            var mesaAdicionada = _usuario.AdicionarMesa(id, mesa);
            return Ok(mesa);
        }
    }
}