using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Taller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTaller { get; set; }
        public string Nombre { get; set; } = null!;
        public string Aula { get; set; } = null!;
        public int IdEdificio { get; set; } = 0!;
        [ForeignKey("IdEdificio")]
        public virtual Edificio? Edificio { get; set; }
        public virtual ICollection<Herramienta>? Herramientas { get; set; }
    }
}
