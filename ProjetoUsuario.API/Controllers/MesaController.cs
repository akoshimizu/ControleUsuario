using Microsoft.AspNetCore.Mvc;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;

namespace ProjetoUsuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;
        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet("ListarMesas")]
        public IActionResult ListarMesas()
        {
            var mesas = _mesaService.FindAllMesa();
            if(mesas is null) return NotFound("Nenhuma mesa registrada");
            return Ok(mesas);
        }

        [HttpGet("BuscarMesaPorId/{id}")]
        public IActionResult BuscarMesaPorId(int id)
        {
            var mesa = _mesaService.FindById(id);
            if(mesa is null) return NotFound("Mesa não encontrada");
            return Ok(mesa);
        }


        [HttpPost("CriarMesa")]
        public IActionResult CriarMesa([FromBody] MesaDTO mesa)
        {
            var novaMesa = _mesaService.Create(mesa);
            if(novaMesa is null) return BadRequest("Mesa existente");
            return Ok(novaMesa);
        }

        [HttpPut("AtualizarMesa")]
        public IActionResult AtualizarMesa([FromBody] MesaDTO mesa)
        {
            var mesaAtualizada = _mesaService.UpdateMesa(mesa);
            return Ok(mesaAtualizada);
        }

        [HttpDelete("DesativarMesa/{id}")]
        public IActionResult DesativarMesa(int id)
        {
            var mesaDeletada = _mesaService.DeleteMesa(id);
            if(mesaDeletada is null) return BadRequest("Mesa com vínculo");
            return Ok(mesaDeletada); 
        }
    }
}