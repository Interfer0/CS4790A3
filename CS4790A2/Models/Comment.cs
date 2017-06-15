using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required]
        [Display(Name = "Comment")]
        public String cmtComment {get;set;}
        [Required]
        [Display(Name = "Date")]
        public DateTime cmtDate { get; set; }



        public User User { get; set; }


    }
}
