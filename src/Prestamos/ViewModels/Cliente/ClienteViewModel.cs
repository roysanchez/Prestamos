using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Negocios;

namespace Prestamos.ViewModels.Cliente
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
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

        [Display(Name = "Nombre completo")]
        public string NombreCompleto
        {
            get { return PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido; }
        }

        [Display(Name = "Nombre titular")]
        public string NombreTitular
        {
            get { return PrimerNombre + " " + PrimerApellido; }
        }

        [Display(Name = "Nombres")]
        public string Nombres
        {
            get { return PrimerNombre + " " + SegundoNombre; }
        }

        [Display(Name = "Apellidos")]
        public string Apellidos
        {
            get { return PrimerApellido + " " + SegundoApellido; }
        }

        [Display(Name = "Fecha nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public int Edad
        {
            get { return DateTime.Now.Year - FechaNacimiento.Year; }
        }
    }
}
