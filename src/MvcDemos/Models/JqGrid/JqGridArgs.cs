namespace MvcDemos.Models.JqGrid
{
    public class JqGridArgs
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortExpression { get; set; }
        public GridSortOrder SortOrder { get; set; }
    }
}