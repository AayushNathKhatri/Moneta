using DataAccess.Service;
using DataAccess.Service.Interface;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Moneta
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

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITranctionService, TransactionService>();
            builder.Services.AddScoped<IDebtService, DebtService>();
            builder.Services.AddScoped<ICalculationService, CalaulationService>();
            builder.Services.AddMudServices();
#endif

            return builder.Build();
        }
    }
}
