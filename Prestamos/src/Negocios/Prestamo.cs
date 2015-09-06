using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negocios
{
    public enum Periodo
    {
        Mensual,
        Trimestral,
        Semestral
    }

    public class Prestamo
    {
        public Prestamo()
        {

        }

        public int Id { get; set; }

        /// <summary>
        /// Porcentaje del prestamo
        /// </summary>
        public int Porciento { get; set; }

        //TODO Habilitar cuando EF7 tenga habilitado Complex Types / Value Objects y eliminar las otras 2 propiedades
        /// <summary>
        /// Monto prestado
        /// </summary>
        //public Dinero Monto { get; set; }

        public Moneda Moneda { get; set; }

        public decimal Monto { get; set; }

        public Periodo FormaPago { get; set; }

        /// <summary>
        /// Cantidad de cuotas a realizar
        /// </summary>
        public int CantCuotas { get; set; }

        /// <summary>
        /// Cantidad de meses del prestamo
        /// </summary>
        public double CantMesesAprox
        {
            get
            {
                return this.CantDias / (365.25 / 12);
            }
        }

        public int CantDias
        {
            get
            {
                return (FechaFin - FechaInicio).Days;
            }
        }

        /// <summary>
        /// Fecha se entrego el dinero
        /// </summary>
        [Required]
        public DateTime FechaDesembolso { get; set; }

        /// <summary>
        /// Fecha de inicio del prestamo
        /// </summary>
        [Required]
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha final de prestamo
        /// </summary>
        [Required]
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Porcentaje de mora
        /// </summary>
        public int PorcMora { get; set; }

        /// <summary>
        /// Cliente con la deuda
        /// </summary>
        [Required]
        public Cliente Deudor { get; set; }

        /// <summary>
        /// Codeudor con la responsabilidad si el deudor no resoponde
        /// </summary>
        public Cliente Codeudor { get; set; }
    }
}
