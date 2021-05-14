using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public class Curso
    {
        [Key]
        public long Id { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public int Numero { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }



    }
    

        

    


}
