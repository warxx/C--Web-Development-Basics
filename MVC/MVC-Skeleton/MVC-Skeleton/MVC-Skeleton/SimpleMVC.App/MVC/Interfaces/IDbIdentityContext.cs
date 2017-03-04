using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.MVC.Interfaces
{
    public interface IDbIdentityContext
    {
        DbSet<Login> Logins { get; set; }
        DbSet<User> Users { get; set; }

        void SaveChanges();
    }
}
