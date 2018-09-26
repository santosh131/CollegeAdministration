using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeAdministration.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required( ErrorMessage ="User Name is required")]
        [MaxLength( 5, ErrorMessage ="Length cannot exceed 5 characters")]
        public string UserName { get; set; }

        [Required( ErrorMessage ="Password is required" )]
        [MaxLength(5,ErrorMessage ="Length cannot exceed 5 characters")]
        public string Password { get; set; }
        public bool ActiveInd { get; set; }
    }
}