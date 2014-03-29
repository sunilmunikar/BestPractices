using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemos.Infrastructure
{
    public interface IMapFrom<T>
    {
    }

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
