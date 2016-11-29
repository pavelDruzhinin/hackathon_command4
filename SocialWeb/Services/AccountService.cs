using System.Linq;
using SocialWeb.DataAccess;

namespace SocialWeb.Services
{
    public class AccountService
    {
        public bool Login(string login, string password)
        {
            using (var db = new SocialWebContext())
            {
                var User = db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);

                return User != null;
            }
        }
    }
}