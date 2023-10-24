using InformBez.Data.Models;
using InformBez.Repository;
using InformBez.Exceptions;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace InformBez.Utilts
{
    public class UsersService
    {
        private readonly UsersRepository usersRepository;

        public UsersService()
        {
            usersRepository = new UsersRepository();
        }

        public static User DeepCopyJSON<User>(User user)
        {
            var jsonString = JsonSerializer.Serialize(user);

            return JsonSerializer.Deserialize<User>(jsonString);
        }

        public async Task CreateNewUser(User user)
        {
            user.Id = Utilts.GetUUID();
            var user1 = DeepCopyJSON<User>(user);
            user1.Password = Utilts.GetHashPassword(user.Password);
            if (user1.Login == null || user1.Password == null || user1.Name == null || user1.Email == null || user1.Phone == null || user1.Address == null)
            {
                throw new NullFieldException("Заполните пустые поля");
            }
            else if (!await usersRepository.CheckUserExist(user1.Id, user1.Login)) await usersRepository.AddUser(user1);
            else throw new AuthFailedException("Пользователь уже существует!");
        }

        public Task<bool> GetUserAuthorizeStatus(string login, string password)
        {
                return usersRepository.CheckUserExist(Utilts.GetUUID(), login, password);
        }
    }
}
