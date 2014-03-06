using Core.Entities;
using GenericRepository.EntityFramework;
using System;

namespace Core.Command
{
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