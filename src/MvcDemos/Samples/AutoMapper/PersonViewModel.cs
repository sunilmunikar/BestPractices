using AutoMapper;
using MvcDemos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Samples
{
    public class PersonViewModel : IMapFrom<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class CustomerViewModel : IHaveCustomMappings
    {
        public string FullName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Person, CustomerViewModel>()
                .ForMember(m => m.FullName, opt =>
                    opt.MapFrom(u => string.Format("{0} {1}", u.FirstName, u.LastName)));
        }
    }
}
