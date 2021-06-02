using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFG_Back.Models;

namespace TFG_Back.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
