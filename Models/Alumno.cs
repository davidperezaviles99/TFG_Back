using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Alumno: User
    {
       public Curso Curso { get; set; }

       public ICollection<Equipo> Equipo { get; set; }
    }
}
