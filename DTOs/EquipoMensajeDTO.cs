using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFG_Back.Models;

namespace TFG_Back.DTOs
{
    public class EquipoMensajeDTO
    {
        public long Id { get; set; }

        public UserDTO User { get; set; }

        public EquipoDTO Equipo { get; set; }

        public Message Message { get; set; }

        public DateTime Date { get; set; }
    }
}
