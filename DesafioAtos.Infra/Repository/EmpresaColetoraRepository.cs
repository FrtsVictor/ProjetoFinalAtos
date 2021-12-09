using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class EmpresaColetoraRepository : BaseRepository<EmpresaColetora>, IEmpresaColetoraRepository
    {
        public EmpresaColetoraRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
          
        }
        //public async Task<EmpresaColetora> GetByName(string name)
        //{
        //    return await dbSet.FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower()));
        //}
    }
}
