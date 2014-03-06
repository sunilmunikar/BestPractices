using System;

namespace Core.Command
{
    public class ChangeTaskStatusCommand : ICommand
    {
        public string TaskId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}