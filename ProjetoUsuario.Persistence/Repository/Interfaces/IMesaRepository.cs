using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository.Interfaces
{
    public interface IMesaRepository
    {
        Task<Mesa> BuscarMesaPorId(int id);
        Task<List<Mesa>> BuscarTodasMesas();
        Task<Mesa> CriarMesa(Mesa mesa);
        Task<Mesa> AtualizarMesa(MesaDTO mesa);
        Task<Mesa> DeletarMesa(int id);
        bool VerificaDuplicidadeMesa(Mesa Usuario);
    }
}