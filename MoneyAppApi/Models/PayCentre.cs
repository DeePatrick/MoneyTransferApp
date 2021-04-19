using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Models
{
    public class PayCentre
    {
        public int Id { get; set; }

        [Display(Name = "Centre Name")]
        [StringLength(100)]
        [Required]
        public string CentreName { get; set; }

        [Display(Name = "Centre Address")]
        [StringLength(100)]
        [Required]
        public string CentreAddress { get; set; }

        [MaxLength(10)]
        [Display(Name = "Centre Account No")]
        [Required]
        public string CentreAccountNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public string UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        [Required]
        public decimal Capital { get; set; }

        public IList<Staff> Staff { get; private set; }

        [MaxLength(10)]
        [Display(Name = "Centre Tab No")]
        public string CentreTabNumber{ get; set; }

        [MaxLength(14)]
        public string CentrePhone { get; set; }


        [MaxLength(10)]
        [Display(Name = "Centre POS No")]
        public string CentrePOSNumber { get; set; }




    }
}

