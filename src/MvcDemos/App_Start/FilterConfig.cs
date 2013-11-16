﻿using System.Web.Mvc;
using FluentSecurity;

namespace MvcDemos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleSecurityAttribute(), 0);
        }
    }
}