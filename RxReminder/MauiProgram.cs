using Microsoft.Extensions.Logging;
//using RxReminder.Data;
//using RxReminder.Services;
using RxReminder.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
//using Plugin.LocalNotification;


namespace RxReminder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                //.UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Register DatabaseContext
            //string dbPath = Path.Combine(FileSystem.AppDataDirectory, "RxReminder.db3");
            //builder.Services.AddSingleton(s => new DatabaseContext(dbPath));

            // Register Services
            //builder.Services.AddSingleton<MedicationService>();
            //builder.Services.AddSingleton<ReminderService>();
            //builder.Services.AddSingleton<INotificationService, NotificationService>();

            // Register ViewModels
            builder.Services.AddTransient<MedicationListViewModel>();
            //builder.Services.AddTransient<MedicationDetailViewModel>();
            builder.Services.AddTransient<MedicationInputFormViewModel>();

            var app = builder.Build();
            return app;
        }
    }
}
