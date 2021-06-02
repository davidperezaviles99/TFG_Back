using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.DTOs
{
    public class MensajeDTO
    {
        public long Id { get; set; }

        public EquipoDTO Equipo { get; set; }

        public long UserId { get; set; }
        public UserDTO User { get; set; }

        public string Name { get; set; }

        public string Asunto { get; set; }

        public string Comentario { get; set; }
    }
}
