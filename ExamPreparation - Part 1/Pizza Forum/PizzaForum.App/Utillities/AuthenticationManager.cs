using System.Linq;
using PizzaForum.Appp.Models;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace PizzaForum.Appp.Utillities
{
    public class AuthenticationManager
    {
        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Data.Data.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive)?.User;
            if (user != null)
            {
                ViewBag.Bag["username"] = user.Username;
            }

            return user;
        }

        public static bool IsAuthenticated(HttpSession session)
        {
            return Data.Data.Context.Logins
                .Any(x => x.SessionId == session.Id && x.IsActive);
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["username"] = null;
            var login = Data.Data.Context.Logins
                .FirstOrDefault(l => l.SessionId == l.SessionId && l.IsActive);
            login.IsActive = false;
            Data.Data.Context.SaveChanges();

            var session = SessionCreator.Create();

            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
