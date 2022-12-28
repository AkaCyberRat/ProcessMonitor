using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Logging
{
    public static class FileLoggerExtensions
    {

        public static ILoggingBuilder AddFileLogging(this ILoggingBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddOptions<FileLoggerOptions>()
                .Bind(configuration
                .GetSection("Logging")
                .GetSection("File")
                .GetSection("Options"));

            builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            return builder;
        }

    }
}
