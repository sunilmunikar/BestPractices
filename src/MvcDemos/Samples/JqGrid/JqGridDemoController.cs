using System.Collections.Generic;
using System.Web.Mvc;
using MvcDemos.Models;
using MvcDemos.Models.JqGrid;

namespace MvcDemos.Controllers
{
    public class JqGridDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetData()
        {
            var data = new List<ReturnObject>();

            for (int i = 0; i < 10; i++)
            {
                data.Add(new ReturnObject()
                             {
                                 id = i,
                                 invdate = "2007-10-01",
                                 name = "test",
                                 note = "note",
                                 amount = "200.00",
                                 tax = "10.00",
                                 total = "210.00"
                             }
                    );
            }

            var result = new JqGridData<ReturnObject>
                             {
                                 page = 1,
                                 records = 10,
                                 rows = data,
                                 total = 10
                             };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }

    public class ReturnObject
    {
        public int id { get; set; }

        public string invdate { get; set; }

        public string name { get; set; }

        public string note { get; set; }

        public string amount { get; set; }

        public string tax { get; set; }

        public string total { get; set; }

        public RequestStatus requestStatus { get; set; }
    }
}