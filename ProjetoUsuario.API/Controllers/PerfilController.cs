using Microsoft.AspNetCore.Mvc;
using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Application.Interfaces;

namespace ProjetoUsuario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfil;
        public PerfilController(IPerfilService perfil)
        {
            _perfil = perfil;
        }

        [HttpGet]
        public IActionResult FindAllPerfil()
        {
            return Ok(_perfil.FindAllPerfil());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var perfil = _perfil.FindById(id);
            if(perfil.Equals(null)) return NotFound();
            return Ok(perfil);
        }

        [HttpPost]
        public IActionResult CreatePerfil([FromBody] Perfil perfil)
        {
            if(perfil.Equals(null)) return BadRequest();
            var perfilCriado = _perfil.Create(perfil); 
            return Ok(perfilCriado);
        }

        [HttpPut]
        public IActionResult UpdatePerfil([FromBody] Perfil perfil)
        {
            if(perfil.Equals(null)) return BadRequest();
            var perfilAtualizado = _perfil.UpdatePerfil(perfil); 
            return Ok(perfilAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerfil(int id)
        {
            _perfil.DeletePerfil(id);
            return NoContent();
        }
    }
}