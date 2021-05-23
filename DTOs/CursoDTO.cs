using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.DTOs
{
    public class CursoDTO
    {

        public long Id { get; set; }

        public long Numero { get; set; }

        public string Name { get; set; }

        public AsignaturaDTO Asignatura { get; set; }
    }
}
