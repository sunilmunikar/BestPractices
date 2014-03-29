using AutoMapper;
using MvcDemos.Infrastructure;
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
            var personVm = new PersonViewModel();

            Mapper.Map(person, personVm);

            //personVm.FullName = string.Format("{0} {1}", person.FirstName, person.LastName);

            return View(personVm);
        }

        public ActionResult CustomMapping()
        {
            var person = new Person() { FirstName = "Sunil", LastName = "Munikar" };
            var customerVm = new CustomerViewModel();

            Mapper.Map(person, customerVm);

            return View(customerVm);
        }

    }




}
