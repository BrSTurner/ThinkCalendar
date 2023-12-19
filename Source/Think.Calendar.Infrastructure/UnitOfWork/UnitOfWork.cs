using Think.Calendar.Domain.UnitOfWork;
using Think.Calendar.Infrastructure.Data;

namespace Think.Calendar.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ThinkCalendarContext _context;

        public UnitOfWork(ThinkCalendarContext context)
        {
            _context = context; 
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
