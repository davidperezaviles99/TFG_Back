using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFG_Back.Models;

namespace TFG_Back.DTOs
{
    public class ProfesorDTO : UserDTO
    {
        public ICollection<EquipoDTO> Equipo { get; set; }
    }
}
