using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Asignaturas
    {
        [Key]
        public long Id { get; set; }

        [StringLength(30, MinimumLength = 1)]
        public long Codigo { get; set; }

        [StringLength(30, MinimumLength = 1)]
        public string Curso { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string Asignatura { get; set; }

        public Profesor Profesor { get; set; }
    }
}
