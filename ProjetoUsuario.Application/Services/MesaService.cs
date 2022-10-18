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
             var mesaAtualizada = _mesaRepository.Create(novaMesa);
            return mesaAtualizada;
        }

        public void DeleteMesa(int id)
        {
            _mesaRepository.DeleteMesa(id);
        }

        public List<Mesa> FindAllMesa()
        {
            var listaMesas = _mesaRepository.FindAllMesa();
            return listaMesas;
        }

        public Mesa FindById(int id)
        {
            var mesa = _mesaRepository.FindById(id);
            return mesa;
        }

        public Mesa UpdateMesa(MesaDTO mesa)
        {
            var mesaAtualizada = _mesaRepository.UpdateMesa(mesa);
            return mesaAtualizada;
        }

        public bool VerificaDuplicidadeMesa(Mesa Usuario)
        {
            throw new NotImplementedException();
        }
    }
}