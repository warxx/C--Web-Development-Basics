using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.Models;

namespace PizzaForum.Appp.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Topic> Topics { get; }

        IRepository<Reply> Replies { get; }

        IRepository<Login> Logins { get; }

        int SaveChanges();
    }
}
