using App.Core;

namespace App.Services.ProcessService
{
    internal interface IProcessService
    {
        Process[] GetActiveProcesses();
        ProcessCompact[] GetActiveProcessesCompact();
        Process GetProcessById(string id);
        Process KillProcessById(string id);
    }
}
