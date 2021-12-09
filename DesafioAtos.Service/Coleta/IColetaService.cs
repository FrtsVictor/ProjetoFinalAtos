using DesafioAtos.Domain.Dtos;

namespace DesafioAtos.Service.Coleta
{
    public interface IColetaService
    {

        Task ColetaPost(CriarColetaDto request);
        Task ColetaPut(EditarColetaDto request);
        Task<ColetaDto> PegaColetaPorId(long id);
        Task<List<ColetaDto>> PegaTodasColeta();
        Task DeletaColeta(long id);
    }
}
