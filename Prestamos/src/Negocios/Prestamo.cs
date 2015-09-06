using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Porcentaje del prestamo
        /// </summary>
        public int Porciento { get; set; }

        /// <summary>
        /// Monto prestado
        /// </summary>
        public Dinero Monto { get; set; }

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
        public DateTime FechaDesembolso { get; set; }

        /// <summary>
        /// Fecha de inicio del prestamo
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha final de prestamo
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Porcentaje de mora
        /// </summary>
        public int PorcMora { get; set; }

        /// <summary>
        /// Cliente con la deuda
        /// </summary>
        public Cliente Deudor { get; set; }

        /// <summary>
        /// Codeudor con la responsabilidad si el deudor no resoponde
        /// </summary>
        public Cliente Codeudor { get; set; }
    }
}
