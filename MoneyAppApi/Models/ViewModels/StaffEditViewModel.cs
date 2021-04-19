using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models.ViewModels
{
    public class StaffEditViewModel:StaffViewModel
    {
        public int Id { get; set; }
        public string ExistingProfilePhoto { get; set; }
    }
}
