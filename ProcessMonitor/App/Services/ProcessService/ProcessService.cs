using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using App.Core;

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

        public ProcessCompact[] GetActiveProcessesCompact()
        {
            _logger.LogDebug("Getting active processes.");

            var processes = System.Diagnostics.Process.GetProcesses();
            var models = new List<ProcessCompact>(processes.Length);

            foreach (var process in processes)
            {
                var model = new ProcessCompact();
                model.Id = process.Id.ToString();
                model.Name = process.ProcessName;

                models.Add(model);
            }

            return models.ToArray();
        }

        public Process GetProcessById(string id)
        {
            _logger.LogDebug($"Getting process by id {id}.");

            if (!int.TryParse(id, out int resultId)){
                var e = new ArgumentException($"Unsupported id format Id={id}");
                _logger.LogError($"Get process error: {e.Message}.");
                throw e;
            }

            var process = System.Diagnostics.Process.GetProcessById(resultId);

            var model = new Process()
            {
                Id = process.Id.ToString(),
                Name = process.ProcessName,
                MachineName = process.MachineName,
                PriorityClass = process.PriorityClass.ToString(),
                StartTime = process.StartTime
            };

            return model;
        }

        public Process KillProcessById(string id)
        {
            _logger.LogDebug($"Kill process by id {id}.");

            if (!int.TryParse(id, out int resultId))
            {
                var e = new ArgumentException($"Unsupported id format Id={id}");
                _logger.LogError($"Kill process error: {e.Message}.");
                throw e;
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
