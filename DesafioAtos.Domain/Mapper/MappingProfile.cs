using AutoMapper;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmpresaColeta, EmpresaColetoraDto>().ReverseMap();
            CreateMap<EmpresaColeta, CriarEmpresaColetoraDto>().ReverseMap();
            CreateMap<EmpresaColeta, EditarEmpresaColetoraDto>().ReverseMap();
        }
    }
}
