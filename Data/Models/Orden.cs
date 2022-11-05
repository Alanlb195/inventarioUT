using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrden { get; set; }
        public int IdUsuario { get; set; } = 0;
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
        public int IdEstatus { get; set; } = 0!;
        [ForeignKey("IdEstatus")]
        public virtual Estatus Estatus { get; set; } = null!;
        public virtual ICollection<DetalleOrden>? DetalleOrdenes { get; set; }
    }
}

