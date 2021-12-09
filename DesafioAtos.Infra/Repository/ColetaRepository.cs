using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class ColetaRepository : BaseRepository<Coleta>, IColetaRepository
    {
        public ColetaRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
