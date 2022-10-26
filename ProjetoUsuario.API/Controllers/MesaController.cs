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
        public async Task<IActionResult> ListarMesas()
        {
            var mesas = await _mesaService.FindAllMesa();
            if(mesas is null) return NotFound("Nenhuma mesa registrada");
            return Ok(mesas);
        }

        [HttpGet("BuscarMesaPorId/{id}")]
        public async Task<IActionResult> BuscarMesaPorId(int id)
        {
            var mesa = await _mesaService.FindById(id);
            if(mesa is null) return NotFound("Mesa não encontrada");
            return Ok(mesa);
        }


        [HttpPost("CriarMesa")]
        public async Task<IActionResult> CriarMesa([FromBody] MesaDTO mesa)
        {
            var novaMesa = await _mesaService.Create(mesa);
            if(novaMesa is null) return BadRequest("Mesa existente");
            return Ok(novaMesa);
        }

        [HttpPut("AtualizarMesa")]
        public async Task<IActionResult> AtualizarMesa([FromBody] MesaDTO mesa)
        {
            var mesaAtualizada = await _mesaService.UpdateMesa(mesa);
            return Ok(mesaAtualizada);
        }

        [HttpDelete("DesativarMesa/{id}")]
        public async Task<IActionResult> DesativarMesa(int id)
        {
            var mesaDeletada = await _mesaService.DeleteMesa(id);
            if(mesaDeletada is null) return BadRequest("Mesa com vínculo");
            return Ok(mesaDeletada); 
        }
    }
}