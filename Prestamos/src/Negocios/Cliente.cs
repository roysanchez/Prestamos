using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocios
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Cliente
    {
        public Cliente()
        {
        }

        public int Id { get; set; }

        public string Cedula { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto
        {
            get { return PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido; }
        }

        public string NombreTitular
        {
            get { return PrimerNombre + " " + PrimerApellido; }
        }
    }
}
