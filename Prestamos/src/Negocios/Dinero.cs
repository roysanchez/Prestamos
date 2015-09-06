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

        public Moneda Moneda { get; set; }

        public decimal Monto { get; set; }
    }
}
