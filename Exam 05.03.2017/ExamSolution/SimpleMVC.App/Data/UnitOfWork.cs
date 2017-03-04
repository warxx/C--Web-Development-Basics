using SimpleMVC.App.Data.Interfaces;
using SimpleMVC.App.Data.Repositories;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext context;
        private IRepository<User> users;
        private IRepository<Model1> categories;
        private IRepository<Model2> topics;
        private IRepository<Model3> replies;
        private IRepository<Model4> logins;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<User> Users
            => this.users ?? (this.users = new Repository<User>(this.context.Users));

        public IRepository<Category> Categories
            => this.categories ?? (this.categories = new Repository<Category>(this.context.Categories));

        public IRepository<Topic> Topics
            => this.topics ?? (this.topics = new Repository<Topic>(this.context.Topics));

        public IRepository<Reply> Replies
            => this.replies ?? (this.replies = new Repository<Reply>(this.context.Replies));

        public IRepository<Login> Logins
            => this.logins ?? (this.logins = new Repository<Login>(this.context.Logins));


        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
