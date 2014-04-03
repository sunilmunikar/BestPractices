using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Samples
{
    public class AutoMapperController : Controller
    {
        public ActionResult SimpleMapping()
        {
            var person = new Person() { FirstName = "Sunil", LastName = "Munikar" };
            PersonViewModel personVm = Mapper.Map<Person, PersonViewModel>(person);

            return View(personVm);
        }

        public ActionResult CustomMapping()
        {
            var person = new Person() { FirstName = "Sunil", LastName = "Munikar" };
            CustomerViewModel customerVm = Mapper.Map<Person, CustomerViewModel>(person);

            return View(customerVm);
        }

    }




}
