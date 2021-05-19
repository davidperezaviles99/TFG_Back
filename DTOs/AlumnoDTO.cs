﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFG_Back.Models;

namespace TFG_Back.DTOs
{
    public class AlumnoDTO: UsersDTO
    {
        public ICollection<Equipo> Equipo { get; set; }

        public Curso Curso { get; set; }

    }
}