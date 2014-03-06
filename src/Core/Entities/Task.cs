using GenericRepository;
using System;

namespace Core.Entities
{
    public class Task : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted;
        public DateTime LastUpdated;
    }
}
