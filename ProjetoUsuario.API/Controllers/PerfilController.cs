using Microsoft.AspNetCore.Mvc;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;

namespace ProjetoUsuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfil;
        public PerfilController(IPerfilService perfil)
        {
            _perfil = perfil;
        }

        [HttpGet("ListarPerfis")]
        public IActionResult FindAllPerfil()
        {
            return Ok(_perfil.FindAllPerfil());
        }

        [HttpGet("BuscarPefilPorId/{id}")]
        public IActionResult FindById(int id)
        {
            var perfil = _perfil.FindById(id);
            if(perfil is null) return NotFound("Perfil não encontrado");
            return Ok(perfil);
        }

        [HttpPost("CriarPerfil")]
        public IActionResult CreatePerfil([FromBody] PerfilDTO perfil)
        {
            if(perfil.Equals(null)) return BadRequest();
            var perfilCriado = _perfil.Create(perfil); 
            if(perfilCriado is null) return BadRequest("perfil existente");
            return Ok(perfilCriado);
        }

        [HttpPut("AtualizarPerfil")]
        public IActionResult UpdatePerfil([FromBody] PerfilDTO perfil)
        {
            if(perfil.Equals(null)) return BadRequest();
            var perfilAtualizado = _perfil.UpdatePerfil(perfil); 
            return Ok(perfilAtualizado);
        }

        [HttpDelete("DesativarPerfil{id}")]
        public IActionResult DeletePerfil(int id)
        {
            var perfilDeletado = _perfil.DeletePerfil(id);
            if (perfilDeletado is null) return BadRequest("Perfil com vínculo");
            return Ok(perfilDeletado);
        }
    }
}