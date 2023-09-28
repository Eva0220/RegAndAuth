using InformBez.Data.Models;
using InformBez.UUID;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformBez.UUID

{
    public class UserAction
    {
        public static void AddUser(User user)
        {
            ApplicationContext context = new();
            context.Users.Add(user);
            context.SaveChanges();
        }
        
        public static async Task<List<User>> GetUsersAsync()
        {
            ApplicationContext context = new();
            List<User> users = await context.Users.ToListAsync();
            
            return users;
        }
        
            public static async Task CreateNewUser (User user)
        {
            var users = await GetUsersAsync();

            user.Id = UUID.GetUUID();
            foreach (User u in users)
            {
                if (user.Id != u.Id || user.Login != u.Login)
                {
                    AddUser(user);
                }
            }

        }
        public static async Task<bool> UserAuthorizeStatus(string login, string password)
        {
            var users = await GetUsersAsync();
  
            User user = users.FirstOrDefault(u => u.Id == UUID.GetUUID());
            if (user != null && user.Login == login && user.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
