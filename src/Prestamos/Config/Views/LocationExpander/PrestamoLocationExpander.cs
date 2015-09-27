using Microsoft.AspNet.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.Config.Views.LocationExpander
{
    public class PrestamoLocationExpander: IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var list = viewLocations.ToList();
            list.Add("/Views/Shared/Partials/{1}/{0}.cshtml");

            return list;

        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // do nothing.. not entirely needed for this 
        }
    }
}
