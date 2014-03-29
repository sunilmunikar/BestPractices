using AutoMapper;
using My.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModular.Features.AutoMapper.Models
{
    public class CustomerViewModel : IHaveCustomMappings
    {
        public string FullName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Person, CustomerViewModel>()
                .ForMember(m => m.FullName, opt =>
                    opt.MapFrom(u => string.Format("{0} {1}", u.FirstName, u.LastName)));
        }
    }
}
