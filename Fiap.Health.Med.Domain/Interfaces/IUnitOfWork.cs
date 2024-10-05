namespace Fiap.Health.Med.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
