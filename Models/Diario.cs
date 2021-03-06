using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Diario
    {

        [Key]
        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(2, MinimumLength = 1)]
        public long Horas { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string Descripcion { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string Link { get; set; }

        public string EvaluacionT { get; set; }

        public string EvaluacionP { get; set; }

        public User User { get; set; }

        public Equipo Equipo { get; set; }

        public Asignatura Asignatura { get; set; }

    }
}
