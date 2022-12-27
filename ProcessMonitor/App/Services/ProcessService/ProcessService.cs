using App.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace App.Services.ProcessService
{
    internal class ProcessService : IProcessService
    {
        private readonly ILogger _logger;

        public ProcessService(ILogger<ProcessService> logger) { 
            _logger = logger;
        }

        public Process[] GetActiveProcesses()
        {
            _logger.LogDebug("Getting active processes.");

            var processes = System.Diagnostics.Process.GetProcesses();
            var models = new List<Process>(processes.Length);
            
            foreach (var process in processes)
            {
                models.Add(new Process()
                {
                    Id = process.Id.ToString(),
                    Name = process.ProcessName,
                    MachineName = process.MachineName,
                    PriorityClass = process.PriorityClass.ToString(),
                    StartTime = process.StartTime,
                });
            }

            return models.ToArray();
        }

        public Process GetProcessById(string id)
        {
            _logger.LogDebug($"Getting process by id {id}.");

            if (!int.TryParse(id, out int resultId)){
                _logger.LogError($"Get process error, unsupported id format : Id={id}.");
                throw new ArgumentException("Unsupported id format");
            }

            var process = System.Diagnostics.Process.GetProcessById(resultId);

            var model = new Process()
            {
                Id = process.Id.ToString(),
                Name = process.ProcessName,
                MachineName = process.MachineName,
                PriorityClass = process.PriorityClass.ToString(),
                StartTime = process.StartTime,
            };

            return model;
        }

        public Process KillProcessById(string id)
        {
            _logger.LogDebug($"Kill process by id {id}.");

            if (!int.TryParse(id, out int resultId))
            {
                _logger.LogError($"Kill process error, unsupported id format : Id={id}.");
                throw new ArgumentException("Unsupported id format");
            }

            var process = System.Diagnostics.Process.GetProcessById(resultId);
            var model = new Process()
            {
                Id = process.Id.ToString(),
                Name = process.ProcessName,
                MachineName = process.MachineName,
                PriorityClass = process.PriorityClass.ToString(),
                StartTime = process.StartTime,
            };

            process.Kill();

            return model;
        }
    }
}
