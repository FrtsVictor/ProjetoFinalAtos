using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.UnitfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;
        public ICustomerRepository Customers { get; private set; }

        public UnitOfWork(DatabaseContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            if (Customers == null)
            {
                Customers = new CustomerRepository(_context, _logger);
            }
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}