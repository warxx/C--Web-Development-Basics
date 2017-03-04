namespace PizzaForum.Appp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PizzaForum.Appp.Data.PizzaForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PizzaForum.Appp.Data.PizzaForumContext context)
        {
        }
    }
}
