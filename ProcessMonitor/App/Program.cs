using System;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using App.Forms;
using App.Services.ProcessService;

namespace App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder(Array.Empty<string>()).Build();
            var services = host.Services;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(services.GetService<MainForm>());
        }


        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(lb =>
                {
                    lb.SetMinimumLevel(LogLevel.Debug);
                    lb.AddDebug();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IProcessService,  ProcessService>();
                    services.AddTransient<MainForm>();
                });
        }
    }
}
