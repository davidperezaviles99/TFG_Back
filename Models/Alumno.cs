using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Alumno: User
    {

        public Tutor Tutor { get; set; }

        public Curso Curso { get; set; }

    }
}
