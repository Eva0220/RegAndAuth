using InformBez.Data.Models;
using InformBez.Repository;
using InformBez.Exceptions;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace InformBez.Utilts
{
    public class UsersService
    {
        private readonly UsersRepository usersRepository;

        public UsersService()
        {
            usersRepository = new UsersRepository();
        }

        public async Task CreateNewUser(User user)
        {
            User user1 = new()
            { 
                Id = Utilts.GetUUID(),
                Login = user.Login,
                Password = Utilts.GetHashPassword(user.Password),
                Name = user.Name,
                Phone = user.Phone,
                Email = user.Email,
                Address = user.Address,
            };
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
