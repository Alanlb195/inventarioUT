using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Multa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMulta { get; set; }
        public int IdOrden { get; set; } = 0!;
        [ForeignKey("IdOrden")]
        public virtual Orden? Orden { get; set; }
        public int IdEstatus { get; set; } = 0!;
        [ForeignKey("IdEstatus")]
        public virtual Estatus? Estatus { get; set; }
    }
}
