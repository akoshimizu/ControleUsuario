using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository.Interfaces
{
    public interface IMesaRepository
    {
        Mesa FindById(int id);
        List<Mesa> FindAllMesa();
        Mesa Create(Mesa mesa);
        Mesa UpdateMesa(MesaDTO mesa);
        Mesa DeleteMesa(int id);
        bool VerificaDuplicidadeMesa(Mesa Usuario);
    }
}