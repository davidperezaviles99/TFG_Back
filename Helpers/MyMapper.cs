using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFG_Back.DTOs;
using TFG_Back.Models;
using AutoMapper;


namespace TFG_Back.Helpers
{
    public class MyMapper: Profile
    {
        public MyMapper()
        {
            CreateMap<User, UsersDTO>();

            CreateMap<UsersDTO, User>();

            CreateMap<Alumno, AlumnoDTO>();

            CreateMap<AlumnoDTO, Alumno>();

            CreateMap<Tutor, TutorDTO>();

            CreateMap<TutorDTO, Tutor>();

            CreateMap<Profesor, ProfesorDTO>();

            CreateMap<ProfesorDTO, Profesor>();

            CreateMap<Asignaturas, AsignaturasDTO>();

            CreateMap<AsignaturasDTO, Asignaturas>();

        }
        
    }
}
