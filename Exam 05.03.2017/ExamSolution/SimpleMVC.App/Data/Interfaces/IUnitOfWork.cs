using SimpleMVC.App.Models;

namespace SimpleMVC.App.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }

        IRepository<T> DbSetName1 { get; }

        IRepository<T> DbSetName2 { get; }

        IRepository<T> DbSetName3 { get; }

        IRepository<T> DbSetName4 { get; }

        int SaveChanges();
    }
}
