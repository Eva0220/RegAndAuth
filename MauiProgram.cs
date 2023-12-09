using BlazorModalDialogs.Dialogs.InputDialog;
using BlazorModalDialogs;
using Microsoft.Extensions.Logging;
using BlazorModalDialogs.Dialogs.MessageDialog;
using InformBez.Services;

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

            builder.Services.AddDbContext<ApplicationContext>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddModalDialogs(typeof(MessageDialog), typeof(InputDialog));
            builder.Services.AddScoped<Radzen.DialogService>();

            builder.Services.AddTransient<AttachedFilesRepository>();
            builder.Services.AddTransient<AttachedFilesRepository>();
            builder.Services.AddTransient<FileChecker>();

            builder.Services.AddScoped<ArchiveManager>(sp => new(".zip", ".secret", ".txt"));
            builder.Services.AddScoped<FileManager>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}