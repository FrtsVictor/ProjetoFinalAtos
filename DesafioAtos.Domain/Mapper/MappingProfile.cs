using AutoMapper;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ColetaDto, Coleta>().ReverseMap();
            CreateMap<CriarColetaDto, Coleta>().ReverseMap();
            CreateMap<EditarColetaDto, Coleta>().ReverseMap();

            CreateMap<EmpresaColetora, EmpresaColetoraDto>().ReverseMap();
            CreateMap<EmpresaColetora, CriarEmpresaColetoraDto>().ReverseMap();
            CreateMap<EmpresaColetora, EditarEmpresaColetoraDto>().ReverseMap();
        }
    }
}
