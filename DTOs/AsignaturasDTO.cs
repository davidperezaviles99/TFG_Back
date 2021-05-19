using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.DTOs
{
    public class AsignaturasDTO
    {
        public long Id { get; set; }

        public long Codigo { get; set; }

        public string Name { get; set; }

        public ProfesorDTO Profesor { get; set; }
    }
}
