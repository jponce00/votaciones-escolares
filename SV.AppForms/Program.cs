using Microsoft.Extensions.DependencyInjection;
using SV.Infrastructure.FileExcel;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Infrastructure.Persistences.Repositories;
using SV.Utilities.Components;

namespace SV.AppForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var loginForm = serviceProvider.GetRequiredService<FormLogin>();

                Application.Run(loginForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<SVContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IReadExcel, ReadExcel>();

            services.AddSingleton<LoginInfo>();

            services.AddScoped<FormGrades>()
                .AddScoped<FormUsers>();

            services.AddSingleton<FormLogin>();
        }
    }
}