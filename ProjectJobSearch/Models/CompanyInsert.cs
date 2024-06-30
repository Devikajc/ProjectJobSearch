using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectJobSearch.Models
{
    public class CompanyInsert
    {
        //public int company_id { get; set; }
        [Required(ErrorMessage = "Enter the name")]
        public string company_name { get; set; }


        [Required(ErrorMessage = "Enter the address")]
        public string company_address { get; set; }


        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid phone number")]
        public long company_phone { get; set; }


        [EmailAddress(ErrorMessage = "Enter the valid email")]
        public string company_email { get; set; }
        public string company_website { get; set; }
        public string company_location { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Compare("password", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }

        public string companymsg { get; set; }
    }
}