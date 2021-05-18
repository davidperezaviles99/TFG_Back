using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TFG_Back.Models
{
    public class Mensaje
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Equipo Equipo { get; set; }

        [StringLength(150, MinimumLength = 2)]
        [Required]
        public string Comentario { get; set; }
    }
}
