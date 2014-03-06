using Core.Entities;
using GenericRepository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Cqrs.QueryHandler
{
    public class TasksByStatusQueryHandler : IQueryHandler<TasksByStatusQuery, TasksByStatusQueryResult>
    {
        private readonly IEntityRepository<Task> _taskRepository;

        public TasksByStatusQueryHandler(IEntityRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TasksByStatusQueryResult Retrieve(TasksByStatusQuery query)
        {
            TasksByStatusQueryResult result = new TasksByStatusQueryResult();
            result.Tasks = _taskRepository.GetAll().Where(x => x.IsCompleted == query.IsCompleted).ToList();
            //result.LastUpdateForAnyTask = result.Tasks.Max(x => x.LastUpdated);
            return result;
        }
    }
}
