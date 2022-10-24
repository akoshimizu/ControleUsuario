using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Persistence.Repository.Interfaces;

namespace ProjetoUsuario.Application.Services
{
    public class MesaService : IMesaService
    {
        private readonly IMesaRepository _mesaRepository;
        public MesaService(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }
        public Mesa Create(MesaDTO mesa)
        {
            Mesa novaMesa = new Mesa(mesa);             
             var mesaAtualizada = _mesaRepository.CriarMesa(novaMesa);
            return mesaAtualizada;
        }

        public List<Mesa> FindAllMesa()
        {
            var listaMesas = _mesaRepository.BuscarTodasMesas();
            return listaMesas;
        }

        public Mesa FindById(int id)
        {
            var mesa = _mesaRepository.BuscarMesaPorId(id);
            return mesa;
        }

        public Mesa UpdateMesa(MesaDTO mesa)
        {
            var mesaAtualizada = _mesaRepository.AtualizarMesa(mesa);
            return mesaAtualizada;
        }

        public Mesa DeleteMesa(int id)
        {
            var mesaDeletada = _mesaRepository.DeletarMesa(id);
            return mesaDeletada;
        }
    }
}