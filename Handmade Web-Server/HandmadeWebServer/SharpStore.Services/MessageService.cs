using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SharpStore.Data;
using SharpStore.Data.Models;

namespace SharpStore.Services
{
    public class MessageService
    {
        private SharpStoreContext context;

        public MessageService()
        {
            this.context = Data.Data.Context;
        }

        public void AddMessageFromPostVars(IDictionary<string, string> vars)
        {
            var message = new Message()
            {
                Sender = vars["email"],
                Subject = vars["subject"],
                MessageText = vars["message-text"]
            };

            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }
    }
}
