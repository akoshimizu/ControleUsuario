using AutoMapper;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Persistence.Repository.Interfaces;

namespace ProjetoUsuario.Application.Services
{
    public class MesaService : IMesaService
    {
        private readonly IMapper _mapper;
        private readonly IMesaRepository _mesaRepository;
        public MesaService(IMesaRepository mesaRepository, IMapper mapper)
        {
            _mesaRepository = mesaRepository;
            _mapper = mapper;
        }
        public async Task<Mesa> Create(MesaDTO mesa)
        {
            //Mesa novaMesa = new Mesa(mesa);
            var novaMesa = _mapper.Map<Mesa>(mesa);
             var mesaAtualizada = await _mesaRepository.CriarMesa(novaMesa);
            return mesaAtualizada;
        }

        public async Task<List<Mesa>> FindAllMesa()
        {
            var listaMesas = await _mesaRepository.BuscarTodasMesas();
            return listaMesas;
        }

        public async Task<Mesa> FindById(int id)
        {
            var mesa = await _mesaRepository.BuscarMesaPorId(id);
            return mesa;
        }

        public async Task<Mesa> UpdateMesa(MesaDTO mesa)
        {
            var mesaAtualizada = await _mesaRepository.AtualizarMesa(mesa);
            return mesaAtualizada;
        }

        public async Task<Mesa> DeleteMesa(int id)
        {
            var mesaDeletada = await _mesaRepository.DeletarMesa(id);
            return mesaDeletada;
        }
    }
}