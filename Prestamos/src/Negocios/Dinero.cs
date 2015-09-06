using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocios
{
    public enum Moneda
    {
        RD,
        US
    }

    public class Dinero
    {
        public Dinero()
        {

        }

        public Moneda moneda { get; set; }

        public decimal monto { get; set; }
    }
}
