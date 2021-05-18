using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Equipo
    {
        [Key]
        public long Id { get; set; }

        public Alumno Alumno { get; set; }

        public Tutor Tutor { get; set; }

        public Profesor Profesor { get; set; }


    }
}
