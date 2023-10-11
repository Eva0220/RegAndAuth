using InformBez.Data.Models;
using BlazorModalDialogs.Dialogs.MessageDialog;
using InformBez.Utilts;

namespace InformBez.Pages
{
    public partial class Auth
    {
        private User user = new();
        private readonly UsersService usersService;

        public Auth()
        {
            usersService = new UsersService();
        }

        private async Task ShowMessage()
        {
            await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Message = "Номер телефона должен начинаться с \"8\"" });
        }

        private async Task CheckUser()
        {
            var check = await usersService.GetUserAuthorizeStatus(user.Login, user.Password);
            if (check == true)
            {
                await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Message = "Пользователь успешно авторизован" });
            }
            else await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Message = "Пользователь не авторизован, просьба пройти регистрацию" });
        }
    }
}
