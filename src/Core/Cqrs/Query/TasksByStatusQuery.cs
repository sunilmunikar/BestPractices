using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Cqrs.QueryHandler
{
    public class TasksByStatusQuery : IQuery
    {
        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }
    }
}
