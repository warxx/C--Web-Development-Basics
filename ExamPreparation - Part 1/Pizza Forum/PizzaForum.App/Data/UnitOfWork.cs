using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.Data.Contracts;
using PizzaForum.Appp.Data.Repositories;
using PizzaForum.Appp.Models;

namespace PizzaForum.Appp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaForumContext context;
        private IRepository<User> users;
        private IRepository<Category> categories;
        private IRepository<Topic> topics;
        private IRepository<Reply> replies;
        private IRepository<Login> logins;

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
