using InformBez.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InformBez.Repository
{
    public class UsersRepository
    {
        public async Task AddUser(User user)
        {
            using ApplicationContext context = new();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> CheckUserExist(string id, string login)
        {
            using ApplicationContext context = new();
            return await context.Users.AnyAsync(u => u.Id == id && u.Login == login);
        }

        public async Task<bool> CheckUserExist(string id, string login, string password)
        {
            using ApplicationContext context = new();

            return await context.Users.AnyAsync(u => u.Id == id && u.Login == login && u.Password == password);
        }

        public static async Task<User> GetUserByID(string id)
        {
            using ApplicationContext context = new();
            User user = new();
            user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public static List<User> GetUsers() 
            {
            using ApplicationContext context = new();
            return context.Users.ToList();
            }
    }
}
