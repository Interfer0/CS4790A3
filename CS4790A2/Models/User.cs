using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public String userName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string userEmail { get; set; }
        
    }
}
