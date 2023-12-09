using InformBez.Data.Models;
using BlazorModalDialogs.Dialogs.MessageDialog;
using InformBez.Utilts;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;
using System.Timers;
using Microsoft.AspNetCore.Components.Forms;
using System.Windows.Forms;
using Microsoft.JSInterop;
using System.DirectoryServices.ActiveDirectory;
using InformBez.Repository;
using System.Text.Json;

namespace InformBez.Pages
{
    public partial class Auth
    {
        [Inject]
        protected NavigationManager navigationManager { get; set; }

        private User user = new();
        private readonly UsersService usersService;
        private System.Timers.Timer timer;
        private string ErrorMessage;

            public Auth()
        {
            usersService = new UsersService();
        }

        static bool isDisabled = false;
        static int counter = 0;

        private async Task CheckUser()
        {
            counter++;
            var check = await usersService.GetUserAuthorizeStatus(user.Login, user.Password);
            if (check == true)
            {
                navigationManager.NavigateTo("/TextEditor");
                //await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Message = "Пользователь успешно авторизован" });
            }

            else if (counter <= 5)
            {
                await dialogsService.Show<MessageDialog, MessageDialogParameters, object>(new MessageDialogParameters { Title = "Ошибка авторизации", Message = "Неверный логин или пароль, либо вы зашли не со своего персонального устройства" });
            }
            else
            {
                ErrorMessage = "Превышено количество попыток ввода! Подождите 10 секунд и попробуйте снова";
                isDisabled = true;
                timer = new()
                {
                    Interval = 10000
                };
                timer.Elapsed += TimerElapsed;
                timer.Start();
                timer.AutoReset = true;
            }
        }
         public void TimerElapsed(object sender, ElapsedEventArgs e)
        { 
            timer.Stop();
            isDisabled = false;
            InvokeAsync(StateHasChanged);
            counter = 0;
            ErrorMessage = null;
        }
    }
}
    
