namespace MvcDemos.Models
{
    public enum RequestStatus : byte
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Closed = 4,
        Cancelled = 5,
        Visiting = 6,
        Working = 7
    }
}