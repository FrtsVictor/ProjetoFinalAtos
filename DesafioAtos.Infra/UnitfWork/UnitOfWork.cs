using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Exceptions;
using DesafioAtos.Infra.Repository;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.UnitfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;
        private ICustomerRepository _cutomerRepository;
        public ICustomerRepository Customers
        {
            get
            {
                if (_cutomerRepository == null)
                    _cutomerRepository = new CustomerRepository(_context, _logger);

                return _cutomerRepository;
            }
            private set => _cutomerRepository = value;
        }

        private IUserRepository _userRepository;
        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context, _logger);

                return _userRepository;
            }
            private set => _userRepository = value;
        }
        private IRoleRepository _roleRepository;
        public IRoleRepository Roles
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepositoy(_context, _logger);

                return _roleRepository;
            }
            private set => _roleRepository = value;
        }

        public UnitOfWork(DatabaseContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
            DetachAllEntities();
        }

        public async Task ExecuteAsync<T>(Func<Task> callback)
        {
            try
            {
                await callback();
                await CompleteAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                throw new DatabaseException();
            }
        }

        
        public async Task<T> ExecuteAsync<T>(Func<Task<T>> callback)
        {
            try
            {
                var result = await callback();
                await CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                throw new DatabaseException();
            }
        }

        public void Dispose()
        {
            _logger.LogWarning("Disposing database contex.");
            _context.Dispose();
        }

        private void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }



        // public async Task<T> ExecuteTransactionAsync<T>(Func<Task<T>> callback)
        // {
        //     try
        //     {
        //         using var transaction = await _context.Database.BeginTransactionAsync();
        //         var result = await callback();
        //         await _context.SaveChangesAsync();
        //         await transaction.CommitAsync();
        //         DetachAllEntities();
        //         return result;
        //     }
        //     catch (Exception e)
        //     {
        //         _logger.LogError(e.InnerException?.Message ?? e.Message);
        //         throw new DatabaseException();
        //     }
        // }
    }
}