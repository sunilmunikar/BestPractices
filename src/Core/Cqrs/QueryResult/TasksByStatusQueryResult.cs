using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Cqrs.QueryHandler
{
    public class TasksByStatusQueryResult : IQueryResult
    {
        public DateTime LastUpdateForAnyTask { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
