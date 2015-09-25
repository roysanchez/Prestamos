using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        [MaxLength(11)]
        [Required]
        public string Cedula { get; set; }
        
        [Required]
        public string PrimerNombre { get; set; }
        
        public string SegundoNombre { get; set; }
        
        [Required]
        public string PrimerApellido { get; set; }
        
        public string SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
