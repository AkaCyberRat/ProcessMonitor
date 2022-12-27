using App.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace App.Services.ProcessService
{
    internal class ProcessService : IProcessService
    {
        private readonly ILogger _logger;

        public ProcessService(ILogger<ProcessService> logger) { 
            _logger = logger;
        }

        public Core.Process[] GetActiveProcesses()
        {
            _logger.LogDebug("Getting active processes.");

            var processes = System.Diagnostics.Process.GetProcesses();
            var models = new List<Core.Process>(processes.Length);
            
            foreach (var process in processes)
            {
                Core.Process model = null;

                try
                {
                    model = new Core.Process();

                    model.Id = process.Id.ToString();
                    model.Name = process.ProcessName;
                    model.MachineName = process.MachineName;
                    model.PriorityClass = process.PriorityClass.ToString();
                    model.StartTime = process.StartTime;
                    
                } 
                catch(Exception e){
                    _logger.LogError($"Process binding exception: {e.Message}");
                }

                models.Add(model);
            }

            return models.ToArray();
        }

        public Core.Process GetProcessById(string id)
        {
            _logger.LogDebug($"Getting process by id {id}.");

            if (!int.TryParse(id, out int resultId)){
                _logger.LogError($"Get process error, unsupported id format : Id={id}.");
                throw new ArgumentException("Unsupported id format");
            }

            var process = System.Diagnostics.Process.GetProcessById(resultId);

            var model = new Core.Process()
            {
                Id = process.Id.ToString(),
                Name = process.ProcessName,
                MachineName = process.MachineName,
                PriorityClass = process.PriorityClass.ToString(),
                StartTime = process.StartTime,
            };

            return model;
        }

        public Core.Process KillProcessById(string id)
        {
            _logger.LogDebug($"Kill process by id {id}.");

            if (!int.TryParse(id, out int resultId))
            {
                _logger.LogError($"Kill process error, unsupported id format : Id={id}.");
                throw new ArgumentException("Unsupported id format");
            }

            var process = System.Diagnostics.Process.GetProcessById(resultId);
            var model = new Core.Process()
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
