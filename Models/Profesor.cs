﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TFG_Back.Models
{
    public class Profesor: User
    {
        public List<Alumno> Alumno { get; set; }
    }
}