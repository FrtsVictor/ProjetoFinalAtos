using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Exceptions;
using DesafioAtos.Infra.Repository;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.UnitWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(
            DatabaseContext context,
            ILoggerFactory loggerFactory,
            IDatabaseConstraintMapper databaseConstraintMapper)
        {
            _databaseConstraintMapper = databaseConstraintMapper;
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }

        private const string DefaultMessage = "Database Exception, please check inner exception for details";
        private readonly DatabaseContext _context = null!;
        private readonly IDatabaseConstraintMapper _databaseConstraintMapper = null!;
        private readonly ILogger _logger = null!;

        private IEmpresaColetoraRepository _empresaColetoraRepository = null!;

        public IEmpresaColetoraRepository EmpresaColetora
        {
            get
            {
                InstanciarRepositoryIfNull(ETipoRepository.EmpresaColetaRepository);
                return _empresaColetoraRepository;
            }
        }

        private IEnderecoRepository _enderecoRepository = null!;

        public IEnderecoRepository Endereco
        {
            get
            {
                InstanciarRepositoryIfNull(ETipoRepository.EnderecoRepository);
                return _enderecoRepository;
            }
        }

        private IUsuarioRepository _userRepository = null!;

        public IUsuarioRepository Users
        {
            get
            {
                InstanciarRepositoryIfNull(ETipoRepository.UsuarioRepository);
                return _userRepository;
            }
        }

        private ICategoriaEmpresaRepository _categoriaEmpresaRepository = null!;

        public ICategoriaEmpresaRepository CategoriaEmpresa
        {
            get
            {
                InstanciarRepositoryIfNull(ETipoRepository.CategoriaEmpresaRepository);
                return _categoriaEmpresaRepository;
            }
        }

        private ICategoriaUsuarioRepository _categoriaUsuarioRepository = null!;

        public ICategoriaUsuarioRepository CategoriaUsuario
        {
            get
            {
                InstanciarRepositoryIfNull(ETipoRepository.CategoriaUsuarioRepository);
                return _categoriaUsuarioRepository;
            }
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
            DetachAllEntities();
        }

        public void Dispose()
        {
            _logger.LogWarning("Disposing database contex");
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

        public void Executar<Task>(Func<Task> callback)
        {
            try
            {
                callback();
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _databaseConstraintMapper.Map(e);
                throw new DatabaseException(DefaultMessage, e);
            }
        }

        public async Task VoidExecutarAsync(Func<Task> callback)
        {
            try
            {
                await callback();
                await SalvarAsync();
            }
            catch (Exception e)
            {
                _databaseConstraintMapper.Map(e);
                throw new DatabaseException(DefaultMessage, e);
            }
        }

        public async Task ExecutarTransacaoAsync(params Func<Task>[] @callbacks)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (var cb in @callbacks)
                {
                    await cb();
                    await SalvarAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                _databaseConstraintMapper.Map(e);
                throw new DatabaseException(DefaultMessage, e);
            }
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

        private void InstanciarRepositoryIfNull(ETipoRepository tipoRepository)
        {
            switch (tipoRepository)
            {
                case ETipoRepository.UsuarioRepository:
                    _userRepository ??= new UsuarioRepository(_context, _logger);
                    break;
                case ETipoRepository.EnderecoRepository:
                    _enderecoRepository ??= new EnderecoRepository(_context, _logger);
                    break;
                case ETipoRepository.EmpresaColetaRepository:
                    _empresaColetoraRepository ??= new EmpresaColetoraRepository(_context, _logger);
                    break;
                case ETipoRepository.CategoriaEmpresaRepository:
                    _categoriaEmpresaRepository ??= new CategoriaEmpresaRepository(_context, _logger);
                    break;
                case ETipoRepository.CategoriaUsuarioRepository:
                    _categoriaUsuarioRepository ??= new CategoriaUsuarioRepository(_context, _logger);
                    break;
                default:
                    throw new DatabaseException("Repositorio inválido");
            }
        }
    }
}