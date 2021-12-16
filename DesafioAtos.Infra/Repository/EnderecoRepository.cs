using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Endereco?>> ObterTodosPorIdEmpresaAsync(int idEmpresa) =>
            await dbSet.Where(x => x.IdEmpresaColeta == idEmpresa).ToListAsync();
    }
}