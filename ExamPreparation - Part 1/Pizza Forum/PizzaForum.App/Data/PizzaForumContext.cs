using System.Security.AccessControl;
using PizzaForum.Appp.Models;

namespace PizzaForum.Appp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaForumContext : DbContext
    {
        // Your context has been configured to use a 'PizzaForumContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PizzaForum.Appp.Data.PizzaForumContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PizzaForumContext' 
        // connection string in the application configuration file.
        public PizzaForumContext()
            : base("PizzaForumContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<Reply> Replies { get; set; }

        public virtual DbSet<Login> Logins { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}