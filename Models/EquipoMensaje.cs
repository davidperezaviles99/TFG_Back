using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class EquipoMensaje
    {

        [Key]
        public long Id { get; set; }

        public User User { get; set; }

        public Equipo Equipo { get; set; }

        public Message Message { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
