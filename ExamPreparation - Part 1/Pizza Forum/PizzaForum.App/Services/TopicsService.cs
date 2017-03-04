using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.BindingModels;
using PizzaForum.Appp.Models;
using PizzaForum.Appp.ViewModels;

namespace PizzaForum.Appp.Services
{
    public class TopicsService : Service
    {
        public IEnumerable<string> GetCategoryNames()
        {
            return this.Context.Categories.Entities.Select(x => x.Name);
        }

        public void AddNewTopicFromBind(NewTopicBindingModel model, User author)
        {
            var category = this.Context.Categories.FirstOrDefault(x => x.Name == model.Category);

            var topic = new Topic()
            {
                Title = model.Title,
                Content = model.Content,
                Category = category,
                Author = author,
                PublishDate = DateTime.Now.Date
            };

            this.Context.Topics.Add(topic);
            this.Context.SaveChanges();
        }

        public DetailTopicViewModel GetDetailTopicVM(int topicId)
        {
            var topic = this.Context.Topics.Find(topicId);

            var detailTopicVM = new DetailTopicViewModel()
            {
                TopicTitle = topic.Title,
                AuthorName = topic.Author.Username,
                Content = topic.Content,
                DateTime = topic.PublishDate
            };

            return detailTopicVM;
        }

        public IEnumerable<DetailsReplyViewModel> GetDetailsRepliesVM(int topicId)
        {
            var topic = this.Context.Topics.Find(topicId);

            var detailsRepliesViewModel = new List<DetailsReplyViewModel>();

            foreach (var reply in topic.Replies)
            {
                var detailsReplyViewModel = new DetailsReplyViewModel()
                {
                    AuthorName = reply.Author.Username,
                    Content = reply.Content,
                    Date = reply.PublishDate,
                    ImageUrl = reply.ImageUrl
                };

                detailsRepliesViewModel.Add(detailsReplyViewModel);
            }

            return detailsRepliesViewModel;
        }

        public void AddNewReply(int topicId, User user, NewReplyBindingModel model)
        {
            var reply = new Reply()
            {
                Content = model.Content,
                PublishDate = DateTime.Now,
                ImageUrl = model.ImageUrl,
                TopicId = topicId,
                Author = user
            };

            this.Context.Replies.Add(reply);
            this.Context.SaveChanges();
        }
    }
}
