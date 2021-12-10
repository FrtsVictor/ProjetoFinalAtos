using DesafioAtos.Domain.Dtos;

namespace DesafioAtos.Service.Coleta
{
    public interface IColetaService
    {

        Task ColetaPost(CriarColetaDto request);
        Task ColetaPut(EditarColetaDto request);
        Task<ColetaDto> GetColetaPorId(long id);
        Task<List<ColetaDto>> GetTodasColeta();
        Task DeletaColeta(long id);
    }
}
