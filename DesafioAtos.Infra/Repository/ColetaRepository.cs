using DesafioAtos.Domain.Entities;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAtos.Infra.Repository
{
    public class ColetaRepository : BaseRepository<Coleta>, IColetaRepository
    {
        public ColetaRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
