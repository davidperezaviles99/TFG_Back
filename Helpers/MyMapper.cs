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
            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>();

            CreateMap<Alumno, AlumnoDTO>();

            CreateMap<AlumnoDTO, Alumno>();

            CreateMap<Tutor, TutorDTO>();

            CreateMap<TutorDTO, Tutor>();

            CreateMap<Profesor, ProfesorDTO>();

            CreateMap<ProfesorDTO, Profesor>();

            CreateMap<EquipoMensaje, EquipoMensajeDTO>();

            CreateMap<Asignatura, AsignaturaDTO>();

            CreateMap<AsignaturaDTO, Asignatura>();

            CreateMap<Curso, CursoDTO>();

            CreateMap<CursoDTO, Curso>();

            CreateMap<Equipo, EquipoDTO>();

            CreateMap<EquipoDTO, Equipo>();

            CreateMap<Diario, DiarioDTO>();

            CreateMap<DiarioDTO, Diario>();

            CreateMap<Evaluacion, EvaluacionDTO>();

            CreateMap<EvaluacionDTO, Evaluacion>();

        }
        
    }
}
