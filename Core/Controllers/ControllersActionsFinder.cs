using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Core
{
    public class ControllerDesc
    {
        public string Name { get; set; }
        public List<ActionDesc> Actions { get; set; }
    }

    public class ActionDesc
    {
        public string Name { get; set; }
    }

    public class ControllersActionsFinder
    {

        public static List<ControllerDesc> GetControllerDescs(Type aType = null)
        {
            var assembly = aType == null ? Assembly.GetExecutingAssembly() : aType.Assembly;

            var controllers = assembly
                .GetTypes()
                .Where(t => !t.IsInterface)
                .ToList()
                .Where(t => t.BaseType == typeof(Controller) || t.BaseType.BaseType != null && t.BaseType.BaseType == typeof(Controller));

            var actions = controllers.SelectMany(t => t.GetMethods()).Where(m => m.IsPublic && !m.IsSpecialName && (
                m.ReturnType == typeof(ActionResult)
                || m.ReturnType.BaseType == typeof(ActionResult)
                || (m.ReturnType.BaseType != null && m.ReturnType.BaseType.BaseType == typeof(ActionResult))
                ));

            return actions.GroupBy(a => a.DeclaringType.Name.Replace("Controller", string.Empty))
                          .Select(g =>
                              new ControllerDesc
                              {
                                  Name = g.Key,
                                  Actions = g.Select(a => a.Name)
                                              .Distinct()
                                              .Select(a => new ActionDesc { Name = a })
                                              .ToList()
                              })
                          .ToList();
        }
    }
}