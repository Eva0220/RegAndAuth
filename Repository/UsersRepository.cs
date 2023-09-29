using InformBez.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformBez.Repository
{
    public class UsersRepository
    {
        public void AddUser(User user)
        {
            using ApplicationContext context = new();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            using ApplicationContext context = new();
            List<User> users = await context.Users.AsNoTrackingWithIdentityResolution().ToListAsync();

            return users;
        }
    }
}
