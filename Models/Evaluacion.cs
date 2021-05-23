using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Evaluacion
    {

        [Key]
        public long Id { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        public string EvaluacionT { get; set; }

        public string EvaluacionP { get; set; }

        public Equipo Equipo { get; set; }

    }
}
