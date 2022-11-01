using AutoMapper;
using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Domain.Mapper
{
    public class MesaProfile : Profile
    {
        public MesaProfile()
        {
            CreateMap<MesaDTO, Mesa>();
        }
    }
}