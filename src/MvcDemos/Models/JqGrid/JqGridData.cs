using System.Collections.Generic;

namespace MvcDemos.Models.JqGrid
{
    public class JqGridData<T>
    {
        public int page { get; set; }
        public int total { get; set; }
        public int records { get; set; }
        public IEnumerable<T> rows { get; set; }
        public object userdata { get; set; }
    }
}