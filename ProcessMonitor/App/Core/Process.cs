using System;

namespace App.Core
{
    internal class Process
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MachineName { get; set; }
        public string PriorityClass { get; set; }
        public DateTime StartTime { get; set; }
    }
}
