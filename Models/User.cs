using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFG_Back.Models
{
    public abstract class User
    {
        [Key]
        public long Id { get; set; }

        [StringLength(45, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [StringLength(70, MinimumLength = 2)]
        [Required]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S*$", ErrorMessage = "Error")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
