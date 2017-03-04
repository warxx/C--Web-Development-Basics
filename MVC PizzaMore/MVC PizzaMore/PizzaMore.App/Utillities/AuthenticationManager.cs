using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.Models;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace PizzaMore.App.Utillities
{
    public class AuthenticationManager
    {
        public static User IsAuthenticated(HttpSession session)
        {
            var login = Data.Data.Context.Logins
                .FirstOrDefault(x => x.sessionId == session.Id && x.IsActive);

            if (login != null)
            {
                return login.User;
            }

            return null;
        }

        public static void Logout(string sessionId, HttpResponse response)
        {
            var login = Data.Data.Context.Logins
                .FirstOrDefault(x => x.sessionId == sessionId && x.IsActive);
            login.IsActive = false;
            Data.Data.Context.SaveChanges();
            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
