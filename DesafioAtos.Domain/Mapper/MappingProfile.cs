using AutoMapper;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coleta, ColetaDto>().ReverseMap();
            CreateMap<EmpresaColetora, EmpresaColetoraDto>().ReverseMap();
        }
    }
}
