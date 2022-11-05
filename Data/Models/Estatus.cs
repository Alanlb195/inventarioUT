using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Estatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstatus { get; set; }
        public string Nombre { get; set; } = null!;
        public virtual ICollection<Herramienta>? Herramientas { get; set; }
        public virtual ICollection<Orden>? Ordenes { get; set; }
        public virtual ICollection<Multa>? Multas { get; set; }

    }
}
