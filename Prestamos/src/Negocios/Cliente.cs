using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocios
{
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
