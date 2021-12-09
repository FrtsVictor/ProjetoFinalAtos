using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DatabaseContext context, ILogger logger) : base(context, logger) { }

    }
}
