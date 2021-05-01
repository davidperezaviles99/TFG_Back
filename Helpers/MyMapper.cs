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

        }
        
    }
}
