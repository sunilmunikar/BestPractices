using AutoMapper;
using MvcModular.Features.AutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModular.Features.AutoMapper
{
    public class AutoMapperController : Controller
    {
        public ActionResult SimpleMapping()
        {
            var person = new Person() { FirstName = "Sunil", LastName = "Munikar" };
            var personVm = new PersonViewModel();

            Mapper.Map(person, personVm);

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
