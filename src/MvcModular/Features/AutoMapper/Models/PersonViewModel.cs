using AutoMapper;
using My.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModular.Features.AutoMapper.Models
{
    public class PersonViewModel : IMapFrom<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

}
