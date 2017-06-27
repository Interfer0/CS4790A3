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
        [Display(Name = "User Name")]
        public String userName { get; set; }
        
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage ="Please Confirm Your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email Address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string userEmail { get; set; }
        
        [Required]
        public int accountType { get; set; }
    }
}
