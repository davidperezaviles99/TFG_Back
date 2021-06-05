using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TFG_Back.Models
{
    public class Message
    {
        [Key]
        public long Id { get; set; }

        [StringLength(300, MinimumLength = 1)]
        public string Description { get; set; }

    }
}
