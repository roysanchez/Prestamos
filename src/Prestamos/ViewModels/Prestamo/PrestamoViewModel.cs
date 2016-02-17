using AutoMapper;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Prestamos.ViewModels.Cliente;

namespace Prestamos.ViewModels.Prestamo
{
    public class Dinero
    {
        [Display(Name = "Moneda")]
        public Moneda Moneda { get; set; }

        [Display(Name = "Monto")]
        public decimal Monto { get; set; }
    }

    public class PrestamoViewModel
    {
        public PrestamoViewModel()
        {
        }

        public int Id { get; set; }

        /// <summary>
        /// Porcentaje del prestamo
        /// </summary>
        [Required]
        [Display(Name = "Tasa")]
        public int? Porciento { get; set; }

        /// <summary>
        /// Monto prestado
        /// </summary>
        [Required]
        public Dinero  Monto { get; set; }

        [Display(Name = "Forma de pago")]
        public Periodo FormaPago { get; set; }

        /// <summary>
        /// Cantidad de cuotas a realizar
        /// </summary>
        [Required]
        [Display(Name = "Cant. Cuotas")]
        public int? CantCuotas { get; set; }

        /// <summary>
        /// Fecha se entrego el dinero
        /// </summary>
        [Required]
        [Display(Name = "Fecha Desembolso")]
        public DateTime? FechaDesembolso { get; set; }

        /// <summary>
        /// Fecha de inicio del prestamo
        /// </summary>
        [Required]
        [Display(Name = "Fecha inicio")]
        public DateTime? FechaInicio { get; set; }

        /// <summary>
        /// Fecha final de prestamo
        /// </summary>
        [Required]
        [Display(Name = "Fecha fin")]
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// Porcentaje de mora
        /// </summary>
        [Display(Name = "Tasa mora")]
        [Required]
        public int? PorcMora { get; set; } = 10;

        //TODO Verificar si el viewModel o si el objeto normal
        /// <summary>
        /// Cliente con la deuda
        /// </summary>
        [Required]
        public ClienteViewModel Deudor { get; set; }

        /// <summary>
        /// Codeudor con la responsabilidad si el deudor no resoponde
        /// </summary>
        public ClienteViewModel Codeudor { get; set; }

        /// <summary>
        /// Cantidad de meses del prestamo
        /// </summary>
        [Display(Name = "Cant. Meses")]
        public double CantMesesAprox
        {
            get
            {
                return this.CantDias / (365.25 / 12);
            }
        }

        [Display(Name = "Cant. Días")]
        public int CantDias
        {
            get
            {
                return (FechaFin.Value - FechaInicio.Value).Days;
            }
        }

    }
}
