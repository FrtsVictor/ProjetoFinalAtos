using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class EmpresaColetoraRepository : BaseRepository<EmpresaColeta>, IEmpresaColetoraRepository
    {
        public EmpresaColetoraRepository(DatabaseContext context, ILogger logger) : base(context, logger) {  }

        public async Task<EmpresaColeta?> ObterPorNome(string name)
        {
            return await dbSet.Where(x => x.Nome.ToLower().Contains(name.ToLower())).FirstOrDefaultAsync();

        }
    }
}
