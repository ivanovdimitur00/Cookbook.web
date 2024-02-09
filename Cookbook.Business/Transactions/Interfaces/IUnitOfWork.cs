namespace Cookbook.Business.Transactions.Interfaces
{
    public interface IUnitOfWork
    {
        bool CommitSaveChanges();
    }
}
