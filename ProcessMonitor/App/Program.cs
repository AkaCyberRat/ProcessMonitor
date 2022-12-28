using System;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using App.Forms;
using App.Services.ProcessService;
using Microsoft.Extensions.Configuration;
using App.Logging;

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
                .ConfigureDefaults(args)
                .ConfigureAppConfiguration(b =>
                {
                    b.AddJsonFile("appsettings.json");
                })
                .ConfigureLogging((ctx, lb) => {
                    lb.AddDebug();
                    lb.AddFileLogging(ctx.Configuration);
                
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IProcessService,  ProcessService>();
                    services.AddTransient<MainForm>();
                });
        }
    }
}
