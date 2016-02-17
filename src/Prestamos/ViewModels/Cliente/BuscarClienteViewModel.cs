using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.ViewModels.Cliente
{
    public class BuscarClienteViewModel
    {
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
    }

}
