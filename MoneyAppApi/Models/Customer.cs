using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models
{

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

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
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage ="invalid Email Format")]

        [Display(Name ="Customer Email")]
        public string Email { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public int PayCentreId { get; set; }

        [Required]
        public PayCentre PayCentre { get; set; }
        public string UploadReceipts { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public string CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public string UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        public Customer()
        {
            FullName = FirstName + " " + LastName;
        }
    }

}










