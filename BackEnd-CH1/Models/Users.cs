using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_CH1.Models
{
    public class Users
    {   
        [Required]
        public String Username { get; set; }
        [Required]
        [Display(Name ="Full name")]
        public String Fullname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public String Car { get; set; }
        public String Food { get; set; }
        [Required]
        public Double Age { get; set; }
    }
}
