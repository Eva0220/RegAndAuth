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
            user.Id = Utilts.GetUUID();
            user.Password = Utilts.GetHashPassword(user.Password);
            if (user.Login == null || user.Password == null || user.Name == null || user.Email == null || user.Phone == null || user.Address == null)
            {
                throw new NullFieldException("Заполните пустые поля");
            }
            else if (!await usersRepository.CheckUserExist(user.Id, user.Login)) await usersRepository.AddUser(user);
            else throw new AuthFailedException("Пользователь уже существует!");
        }

        public Task<bool> GetUserAuthorizeStatus(string login, string password)
        {
                return usersRepository.CheckUserExist(Utilts.GetUUID(), login, password);
        }
    }
}
