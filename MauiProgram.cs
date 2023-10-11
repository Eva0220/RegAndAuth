using BlazorModalDialogs.Dialogs.InputDialog;
using BlazorModalDialogs;
using InformBez.Data;
using Microsoft.Extensions.Logging;
using BlazorModalDialogs.Dialogs.MessageDialog;

namespace InformBez
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddModalDialogs(typeof(MessageDialog), typeof(InputDialog));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}