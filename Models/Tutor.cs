using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Tutor: User
    {

        public List<Alumno> Alumno { get; set; }

        public Profesor Profesor { get; set; }
    }
}
