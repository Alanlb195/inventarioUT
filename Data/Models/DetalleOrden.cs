using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DetalleOrden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleOrden { get; set; }
        public int Cantidad { get; set; }
        public int IdOrden { get; set; }
        [ForeignKey("IdOrden")]
        public virtual Orden? Orden { get; set; }
        public int IdHerramienta { get; set; }
        [ForeignKey("IdHerramienta")]
        public virtual Herramienta? Herramienta { get; set; }
    }
}
