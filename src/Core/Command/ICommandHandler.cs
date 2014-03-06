using Core.Entities;
using GenericRepository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Command
{
    public interface ICommand
    {

    }

    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }

    public class ChangeTaskStatusCommand : ICommand
    {
        public string TaskId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class ChangeTaskStatusCommandHandler
        : ICommandHandler<ChangeTaskStatusCommand>
    {
        private readonly IEntityRepository<Task> _db;

        public ChangeTaskStatusCommandHandler(IEntityRepository<Task> db)
        {
            if (db == null) { throw new ArgumentNullException("db"); }
            _db = db;
        }

        public virtual void Handle(ChangeTaskStatusCommand command)
        {
            if (command == null) throw new ArgumentException("command");

            var task = new Core.Entities.Task()
            {
                IsCompleted = command.IsCompleted,
                LastUpdated = command.UpdatedOn
            };

            _db.Add(task);
            _db.Save();
        }
    }
}
