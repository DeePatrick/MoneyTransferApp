using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models.ViewModels
{
    public class CustomerViewModel
    {

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

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "invalid Email Format")]

        [Display(Name = "Customer Email")]
        public string Email { get; set; }
        public IList<Transaction> Transactions { get; private set; }

        [Required]
        public int PayCentreId { get; set; }

       
        public PayCentre PayCentre { get; set; }

        [Required(ErrorMessage = "Please choose file for upload.")]
        [Display(Name = "Upload Receipt")]
        public List<IFormFile> ProfileImages { get; set; }

        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}

