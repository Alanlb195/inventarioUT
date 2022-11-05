using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Herramienta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHerramienta { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; } = 0!;
        public string Urlimagen { get; set; } = null!;
        public int IdMarca { get; set; } = 0!;
        [ForeignKey("IdMarca")]
        public virtual Marca? Marca { get; set; }
        public int IdTaller { get; set; } = 0!;
        [ForeignKey("IdTaller")]
        public virtual Taller? Taller { get; set; }
        public int IdEstatus { get; set; } = 0!;
        [ForeignKey("IdEstatus")]
        public virtual Estatus? Estatus { get; set; }
        public virtual ICollection<DetalleOrden>? DetalleOrdenes { get; set; }
    }
}
