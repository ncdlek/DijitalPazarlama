using DijitalPazarlama.Data;
using DijitalPazarlama.Model;
using System.Linq;

namespace DijitalPazarlama.Service
{
    public class AppUserService
    {
        public AppUser FindByUsername(string username)
        {
            AppUser user = Database.Users.FirstOrDefault(x => x.Username == username);

            return user;
        }

        public bool isLoginCorrect(string u, string p)
        {
            bool existingUser = Database.Users.Any(x => x.Username == u && x.Password == p);

            return existingUser;
        }

        public bool isExistingUser(string u)
        {
            bool existingUser = Database.Users.Any(x => x.Username == u);

            return !existingUser;
        }
    }
}
