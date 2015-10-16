using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Prestamos.Extensions
{
    public static class PrestamosExtension
    {
        //stackoverflow.com/questions/2396422/c-sharp-merge-two-objects-together-at-runtime
        public static void MergeWith<T>(this T primary, T secondary)
        {
            foreach (var pi in typeof(T).GetProperties())
            {
                var priValue = pi.GetGetMethod().Invoke(primary, null);
                var secValue = pi.GetGetMethod().Invoke(secondary, null);
                if (secValue != null || (pi.PropertyType.GetTypeInfo().IsValueType && priValue.Equals(Activator.CreateInstance(pi.PropertyType))))
                {
                    pi.GetSetMethod().Invoke(primary, new object[] { secValue });
                }
            }
        }
    }
}
