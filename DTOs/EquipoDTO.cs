using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.DTOs
{
    public class EquipoDTO
    {
        public long Id { get; set; }

        public long AlumnoId { get; set; }

        public TutorDTO Tutor { get; set; }

        public ProfesorDTO Profesor { get; set; }
    }
}
