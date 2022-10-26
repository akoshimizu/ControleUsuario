using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Application.Interfaces
{
    public interface IMesaService
    {
        Task<Mesa> FindById(int id);
        Task<List<Mesa>> FindAllMesa();
        Task<Mesa> Create(MesaDTO mesa);
        Task<Mesa> UpdateMesa(MesaDTO mesa);
        Task<Mesa> DeleteMesa(int id);
    }
}