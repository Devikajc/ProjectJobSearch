using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectJobSearch.Models
{
    public class logincls
    {
        [Required(ErrorMessage = "Enter the username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        public string password { get; set; }

        public string msg { get; set; }
        public string ltype { get; set; }
    }
}