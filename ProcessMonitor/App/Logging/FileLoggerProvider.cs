using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App.Logging
{
    [ProviderAlias("File")]
    public class FileLoggerProvider : ILoggerProvider
    {
        public FileLoggerOptions Options { get; }


        public FileLoggerProvider(IOptions<FileLoggerOptions> options)
        {
            Options = options.Value;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(this);
        }

        public void Dispose()
        {

        }
    }
}
