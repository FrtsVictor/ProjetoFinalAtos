using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Usuario?> ObterPorLoginAsync(string login) => await dbSet
            .SingleOrDefaultAsync(x => x.Login.Equals(login));
    }
}