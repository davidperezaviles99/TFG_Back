using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.DTOs
{
    public class EvaluacionDTO
    {

        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string EvaluacionT { get; set; }

        public string EvaluacionP { get; set; }

        public EquipoDTO Equipo { get; set; }
    }
}
