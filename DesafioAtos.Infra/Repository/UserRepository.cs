using DesafioAtos.Domain.Entities;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DesafioAtos.Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context, ILogger logger) : base(context, logger) { }

        public async Task<User> GetByUsername(string username)
        { 
            var user = await dbSet.Where(x => x.Username.ToLower() == username.ToLower())
                                   .AsNoTracking()
                                   .ToListAsync();

            return user.FirstOrDefault();
        }
    }
}