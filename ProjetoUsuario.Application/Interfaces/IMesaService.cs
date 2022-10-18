using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Application.Interfaces
{
    public interface IMesaService
    {
         Mesa FindById(int id);
        List<Mesa> FindAllMesa();
        Mesa Create(MesaDTO mesa);
        Mesa UpdateMesa(MesaDTO mesa);
        void DeleteMesa(int id);
        bool VerificaDuplicidadeMesa(Mesa Usuario);
    }
}