using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public int Matricula { get; set; } = 0!;
        public int IdRolUsuario { get; set; } = 0!;
        [ForeignKey("IdRolUsuario")]
        public virtual RolUsuario? RolUsuario { get; set; }
        public virtual ICollection<Orden>? Ordenes { get; set; }

    }
}