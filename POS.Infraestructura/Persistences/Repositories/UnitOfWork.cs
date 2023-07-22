using POS.Infrastructure.Persistences.Context;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosContext _context;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(PosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Category = new CategoryRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
