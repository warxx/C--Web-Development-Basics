using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NotesAppContext : DbContext, IDbIdentityContext
    {
        // Your context has been configured to use a 'NotesAppContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SimpleMVC.App.Data.NotesAppContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NotesAppContext' 
        // connection string in the application configuration file.
        public NotesAppContext()
            : base("name=NotesAppContext")
        {
        }

        public DbSet<Login> Logins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public void SaveChanges()
        {
            this.SaveChanges();
        }

        public virtual  DbSet<Note> Notes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}