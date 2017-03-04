using SharpStore.Data.Models;

namespace SharpStore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStore.Data.SharpStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SharpStore.Data.SharpStoreContext context)
        {
            context.Knives.AddOrUpdate(knife=>knife.Name, new Knife[]
            {
                new Knife()
                {
                    Name = "Karambit ★ (Vanilla)",
                    Price = 131.55m,
                    Url = "https://steamcommunity-a.akamaihd.net/economy/image/-9a81dlWLwJ2UUGcVs_nsVtzdOEdtWwKGZZLQHTxDZ7I56KU0Zwwo4NUX4oFJZEHLbXU5A1PIYQh5hlcX0nvUOGsx8DdQBJjIAVHubSaIAlp1fb3ejxQ7dG0nZTFz_WgaurTwzMA6ZFz0-qW99mn0Qzk_EJoYWylJtSXe1c9aAnSq1C8l_Cv28F7-X3KYA/360fx360f"
                },
                new Knife
                {
                    Name = "Butterfly Knife | Fade",
                    Price = 110.67m,
                    Url = "https://steamcommunity-a.akamaihd.net/economy/image/-9a81dlWLwJ2UUGcVs_nsVtzdOEdtWwKGZZLQHTxDZ7I56KU0Zwwo4NUX4oFJZEHLbXH5ApeO4YmlhxYQknCRvCo04DEVlxkKgpovbSsLQJf0ebcZThQ6tCvq4GKqPH1N77ummJW4NFOhujT8om7igW1qUY6MWqmcIadcw47MFrW_FK9xbzpgZ607Z7PzSAxuXYg53-Llwv330-D9XTwcQ/360fx360f"
                },
                new Knife
                {
                    Name = "Karambit | Bright Water",
                    Price = 229.28m,
                    Url = "https://steamcommunity-a.akamaihd.net/economy/image/-9a81dlWLwJ2UUGcVs_nsVtzdOEdtWwKGZZLQHTxDZ7I56KU0Zwwo4NUX4oFJZEHLbXU5A1PIYQh5hlcX0nvUOGsx8DdQBJjIAVHubSaIAlp1fb3ejxQ7dG0nZTFz_WgaurTwzMA6ZFz0-qW99mn0Qzk_EJoYWylJtSXe1c9aAnSq1C8l_Cv28F7-X3KYA/360fx360f"
                },
                new Knife
                {
                    Name = "★ FLIP KNIFE | MARBLE FADE",
                    Price = 192.86m,
                    Url = "https://steamcommunity-a.akamaihd.net/economy/image/-9a81dlWLwJ2UUGcVs_nsVtzdOEdtWwKGZZLQHTxDZ7I56KU0Zwwo4NUX4oFJZEHLbXH5ApeO4YmlhxYQknCRvCo04DEVlxkKgpovbSsLQJf1f_BYQJD4eO7lZKJm_LLNbrVk1Rd4cJ5ntbN9J7yjRrh_BJlamqidoCTcQRsMArX_lPqkufp0J7p7sidn3trvichsy7YzRG_n1gSORYEYb_6/"
                }
            });
        }
    }
}
