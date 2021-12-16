using AutoMapper;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmpresaColetora, EmpresaColetoraDto>().ReverseMap();
            CreateMap<EmpresaColetora, CriarEmpresaColetoraDto>().ReverseMap();
            CreateMap<EmpresaColetora, EditarEmpresaColetoraDto>().ReverseMap();
        }
    }
}