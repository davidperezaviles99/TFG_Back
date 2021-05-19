using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Tutor: User
    {

        [StringLength(70, MinimumLength = 2)]
        [Required]
        public string NombreEmpresa { get; set; }


        public ICollection<Equipo> Equipo { get; set; }

    }
}
