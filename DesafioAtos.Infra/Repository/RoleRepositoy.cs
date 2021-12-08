using DesafioAtos.Domain.Entities;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository;

public class RoleRepositoy : BaseRepository<Role>, IRoleRepository
{
    public RoleRepositoy(DatabaseContext context, ILogger logger) : base(context, logger) { }
}