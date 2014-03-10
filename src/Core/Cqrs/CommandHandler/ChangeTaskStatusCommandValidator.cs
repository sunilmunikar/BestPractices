using Core.Entities;
using Core.Services.Validation;
using GenericRepository.EntityFramework;
using System;
using System.Collections.Generic;

namespace Core.Command
{
    public class ChangeTaskStatusCommandValidator
        : IValidator<ChangeTaskStatusCommand>
    {
        private IEntityRepository<Task> _db;

        public ChangeTaskStatusCommandValidator(IEntityRepository<Task> db)
        {
            if (db == null) { throw new ArgumentNullException("db"); }
            _db = db;
        }

        public IEnumerable<ValidationResult> Validate(ChangeTaskStatusCommand model)
        {
            var changeTaskStatus = this._db.GetSingle(model.TaskId);

            if (changeTaskStatus == null)
                yield return new ValidationResult("TaskId", "Task doesn't exist");
        }
    }
}