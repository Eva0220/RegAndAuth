using InformBez.Data.Models;
using BlazorModalDialogs.Dialogs.MessageDialog;
using InformBez.Utilts;
using InformBez.Exceptions;

namespace InformBez.Pages
{
    public partial class Reg
    {
        private User user = new();
        private readonly UsersService usersService;

        public Reg()
        {
            usersService = new UsersService();
        }
        private void HandleValidSubmit()
        {

        }

        public async Task TryCreateUser()
        {
            try
            {
                await usersService.CreateNewUser(user);
                await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Message = "Пользователь успешно зарегистрирован!" });
            }
            catch  (NullFieldException ex)
            {
                await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Title = "Ошибка", Message = ex.Message });
            }
            catch (AuthFailedException ex)
            {
                await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Title = "Ошибка регистрации", Message = ex.Message });
            }
        }

        private async Task ShowMessage()
        {
            await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Message = "Номер телефона должен начинаться с \"8\"" });
        }
    }
}