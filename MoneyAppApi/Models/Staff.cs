
using Microsoft.AspNetCore.Identity;
using MoneyApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Please choose Date of Birth")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

  
        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }

     
        [Required(ErrorMessage = "Please choose Local Govt")]
        public string LocalGovt { get; set; }

     
        [Required]
        public string Address { get; set; }

        [PersonalData]
        public string Town { get; set; }
        [PersonalData]
        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please enter salary")]
        public int Salary { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime UpdateDate { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
        public string ProfilePicture { get; set; }

        public int Loan { get; set; }

        public int Debt { get; set; }

        public Staff()
        {
            FullName = FirstName + " " + LastName;
        }
    }
}








