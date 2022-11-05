using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Plazo
    {
        [Key]
        public int IdPlazo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public int IdOrden { get; set; } = 0!;
        [ForeignKey("IdOrden")]
        public virtual Orden? Orden { get; set; }
    }
}
