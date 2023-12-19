namespace Think.Calendar.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
