using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace App.Logging
{
    public class FileLogger : ILogger
    {
        private readonly static object _locker;
        private readonly FileLoggerProvider _provider;


        public FileLogger(FileLoggerProvider provider)
        {
            _provider = provider;
        }

        static FileLogger()
        {
            _locker = new object();
        }


        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            Directory.CreateDirectory(_provider.Options.JournalsFolder);
            var fullFilePath = _provider.Options.JournalsFolder + Path.DirectorySeparatorChar + _provider.Options.JournalName.Replace("{timestamp}", DateTime.UtcNow.ToString("yyyy-MM-dd"));
            var logRecord = string.Format("{0} [{1}] {2} {3}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), logLevel.ToString(), formatter(state, exception), (exception != null ? exception.StackTrace : ""));

            lock (_locker)
            {
                try
                {
                    using (var streamWriter = new StreamWriter(path: fullFilePath, append: true))
                    {
                        streamWriter.WriteLine(logRecord);
                    }
                }
                catch
                {
                    Console.WriteLine("LOG ERROR");
                }
            }
        }
    }
}
