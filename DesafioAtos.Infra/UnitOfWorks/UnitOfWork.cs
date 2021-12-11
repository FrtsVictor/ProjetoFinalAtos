using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Exceptions;
using DesafioAtos.Infra.Repository;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private const string DefaultMessage = "Database Exception, please check inner exception for details";
        private readonly DatabaseContext _context;
        private readonly IDatabaseConstraintMapper _databaseConstraintMapper;
        private readonly ILogger _logger;
        private IEmpresaColetoraRepository _empresaColetoraRepository;
        private IEnderecoRepository _enderecoRepository;
        private IUsuarioRepository _userRepository;


        public IEmpresaColetoraRepository EmpresaColetoraRepository
        {
            get
            {
                if (_empresaColetoraRepository == null)
                    _empresaColetoraRepository = new EmpresaColetoraRepository(_context, _logger);
                return _empresaColetoraRepository;
            }
            private set => _empresaColetoraRepository = value;
        }


        public IEnderecoRepository EnderecoRepository
        {
            get
            {
                if (_enderecoRepository == null)
                    _enderecoRepository = new EnderecoRepository(_context, _logger);
                return _enderecoRepository;
            }
            private set => _enderecoRepository = value;
        }
        public IUsuarioRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UsuarioRepository(_context, _logger);

                return _userRepository;
            }
            private set => _userRepository = value;
        }        

        public UnitOfWork(DatabaseContext context, ILoggerFactory loggerFactory,
            IDatabaseConstraintMapper databaseConstraintMapper)
        {
            _databaseConstraintMapper = databaseConstraintMapper;
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
            DetachAllEntities();
        }

        public async Task VoidExecutarAsync<T>(Func<Task<T>> function)
        {
            await ExecutarAsync<T>(function);
        }


        public async Task<T> ExecutarAsync<T>(Func<Task<T>> callback)
        {
            try
            {
                var result = await callback();
                await SalvarAsync();
                return result;
            }
            catch (Exception e)
            {
                _databaseConstraintMapper.Map(e);
                throw new DatabaseException(DefaultMessage, e);
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