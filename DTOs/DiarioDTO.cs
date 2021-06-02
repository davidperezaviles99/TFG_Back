using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.DTOs
{
    public class DiarioDTO
    {

        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long Horas { get; set; }

        public string Descripcion { get; set; }

        public string Link { get; set; }

        public string EvaluacionT { get; set; }

        public string EvaluacionP { get; set; }

        public long UserId { get; set; }
        public  UserDTO User { get; set; }

        public EquipoDTO Equipo { get; set; }

        public AsignaturaDTO Asignatura { get; set; }
    }
}
