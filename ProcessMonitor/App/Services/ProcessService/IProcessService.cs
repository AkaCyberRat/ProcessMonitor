using App.Core;

namespace App.Services.ProcessService
{
    internal interface IProcessService
    {
        Process[] GetActiveProcesses();
        Process GetProcessById(string id);
        Process KillProcessById(string id);
    }
}
