using GenericRepository;
using System;

namespace Core.Entities
{
    public class Task : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
