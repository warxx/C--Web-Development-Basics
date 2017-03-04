using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.ViewModels;

namespace PizzaForum.Appp.Services
{
    public class HomeService : Service
    {
        public IEnumerable<TopicsViewModel> GetTopicsViewModel()
        {
            var viewModels = new List<TopicsViewModel>();

            foreach (var topic in this.Context.Topics.Entities.Take(10))
            {
                var model = new TopicsViewModel()
                {
                    Id = topic.Id,
                    TopicTitle = topic.Title,
                    CategoryName = topic.Category.Name,
                    Author = topic.Author.Username,
                    DateTime = topic.PublishDate,
                    RepliesCount = topic.Replies.Count
                };

                viewModels.Add(model);
            }

            return viewModels;
        }
    }
}
