using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectJobSearch.Models
{
   
    public class CheckBoxListHelper
    {
        public string value { get; set; }
        public string text { get; set; }
        public bool ischecked { get; set; }
    }

    public class SkillCheckBoxListHelper
    {
        public string svalue { get; set; }
        public string stext { get; set; }
        public bool sischecked { get; set; }
    }

    public class UserInsert
    {
      
        public List<SkillCheckBoxListHelper> MySkills { get; set; }
        public string[] selectedskill { get; set; }
        public List<CheckBoxListHelper> MyFavouriteQual { get; set; }
        public string[] selectedqual { get; set; }
        
        [Required(ErrorMessage = "Enter the name")]
        public string user_name { get; set; }
        [Range(18, 80, ErrorMessage = "Enter the age")]
        public int user_age { get; set; }
        [Required(ErrorMessage = "Enter the address")]
        public string user_address { get; set; }

        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid phone number")]
        public long user_phone { get; set; }
        [EmailAddress(ErrorMessage = "Enter the valid email")]
        public string user_email { get; set; }
        public string user_qualification { get; set; }
        public string user_skills { get; set; }
        public int user_experience { get; set; }
        public string user_resume { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Compare("password", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }

        public string usermsg { get; set; }
    }
}