using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(11, ErrorMessage = "La cédula no puede tener mas de 11 caracteres")]
        public string Cedula { get; set; }

        [Display(Name = "Primer nombre")]
        [Required(ErrorMessage = "El primer nombre es obligatorio")]
        public string PrimerNombre { get; set; }

        [Display(Name = "Segundo nombre")]
        public string SegundoNombre { get; set; }

        [Display(Name = "Primer apellido")]
        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCompleto
        {
            get { return PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido; }
        }

        [Display(Name = "Nombre")]
        public string NombreTitular
        {
            get { return PrimerNombre + " " + PrimerApellido; }
        }
    }
}
