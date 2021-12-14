using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class EmpresaColetoraRepository : BaseRepository<EmpresaColetora>, IEmpresaColetoraRepository
    {
        public EmpresaColetoraRepository(DatabaseContext context, ILogger logger) : base(context, logger) { }

        public async Task<EmpresaColetora?> ObterPorEmail(string email) => await dbSet
            .SingleOrDefaultAsync(x => x.Email.Equals(email));

        public async Task<EmpresaColetora?> ObterPorNome(string name) => await dbSet
            .Where(x => x.Nome.ToLower().Contains(name.ToLower()))
            .FirstOrDefaultAsync();
    }
}
