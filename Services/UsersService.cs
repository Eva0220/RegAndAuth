using InformBez.Data.Models;
using InformBez.Repository;
using InformBez.Utilts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformBez.Utilts
{
    public class UsersService
    {
        public async Task CreateNewUser(User user)
        {
            UsersRepository usersRepository = new();
            var users = await usersRepository.GetUsersAsync();

            user.Id = Utilts.GetUUID();
            foreach (User u in users)
            {
                if (user.Id != u.Id || user.Login != u.Login)
                {
                    usersRepository.AddUser(user);
                }
            }

        }
        public async Task<bool> GetUserAuthorizeStatus(string login, string password)
        {
            UsersRepository usersRepository = new();
            var users = await usersRepository.GetUsersAsync();

            User user = users.FirstOrDefault(u => u.Id == Utilts.GetUUID());
            if (user != null && user.Login == login && user.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
