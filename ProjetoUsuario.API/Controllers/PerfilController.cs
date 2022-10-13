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

        [HttpPost]
        public IActionResult CreatePerfil([FromBody] Perfil perfil)
        {
            var perfilCriado = _perfil.Create(perfil); 
            return Ok(perfilCriado);
        }
    }
}