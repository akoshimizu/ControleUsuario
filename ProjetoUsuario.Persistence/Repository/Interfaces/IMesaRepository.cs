using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository.Interfaces
{
    public interface IMesaRepository
    {
        Mesa BuscarMesaPorId(int id);
        List<Mesa> BuscarTodasMesas();
        Mesa CriarMesa(Mesa mesa);
        Mesa AtualizarMesa(MesaDTO mesa);
        Mesa DeletarMesa(int id);
        bool VerificaDuplicidadeMesa(Mesa Usuario);
    }
}