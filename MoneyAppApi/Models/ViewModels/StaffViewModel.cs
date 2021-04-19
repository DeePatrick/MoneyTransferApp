using Microsoft.AspNetCore.Http;
using MoneyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models.ViewModels
{
    public class StaffViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Please choose gender")]

        public DateTime DOB { get; set; }
        public string Gender { get; set; }

       
        public string LocalGovt { get; set; }

     
        public string Address { get; set; }
       
        public string Town { get; set; }
      
        public string State { get; set; }

        public string Position { get; set; }

        [Required(ErrorMessage = "Please enter salary")]
        public int Salary { get; set; }

        public string UpdateDate { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }

        public int Loan { get; set; }

        public int Debt { get; set; }
    }
}

