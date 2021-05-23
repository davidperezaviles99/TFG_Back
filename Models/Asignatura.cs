using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Asignatura
    {
        [Key]
        public long Id { get; set; }

        public long Codigo { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public Profesor Profesor { get; set; }

    }
}