using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class CategoriaEmpresaRepository : BaseRepository<CategoriaEmpresa>, ICategoriaEmpresaRepository
    {
        public CategoriaEmpresaRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }

        
    }
}