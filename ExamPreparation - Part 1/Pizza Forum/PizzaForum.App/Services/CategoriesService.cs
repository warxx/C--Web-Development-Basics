using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.BindingModels;
using PizzaForum.Appp.Models;
using PizzaForum.Appp.ViewModels;
using SimpleHttpServer.Models;

namespace PizzaForum.Appp.Services
{
    public class CategoriesService : Service
    {
        public AllViewModel GetAllCategories(HttpSession session)
        {
            var categories = this.Context.Categories.Entities
                .Select(cat => new AllCategoryViewModel()
                {
                    Id = cat.Id,
                    CategoryName = cat.Name
                });

            var viewModel = new AllViewModel()
            {
                Categories = categories
            };

            return viewModel;
        }

        public void AddNewCategoryFromBind(NewCategoryBindingModel model)
        {
            var category = new Category()
            {
                Name = model.Name
            };

            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public EditCategoryViewModel GetEditCategoryViewModel(int categoryId)
        {
            var category = this.Context.Categories.Find(categoryId);

            var model = new EditCategoryViewModel()
            {
                Id = categoryId,
                CategoryName = category.Name
            };

            return model;
        }

        public void EditCategoryName(EditCategoryBindingModel model)
        {
            var category = this.Context.Categories.Find(model.CategoryId);
            category.Name = model.Name;
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            this.Context.Categories.Remove(categoryId);
            this.Context.SaveChanges();
        }
    }
}
