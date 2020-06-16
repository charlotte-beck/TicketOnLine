using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb_ASPCore.Models
{
    public class UpdateUserForm
    {
        //public int UserId { get; set; }
        [MaxLength(75)]
        public string FirstName { get; set; }
        [MaxLength(75)]
        public string LastName { get; set; }
        [EmailAddress]
        [MaxLength(384)]
        public string Email { get; set; }
        [MaxLength(20)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Passwd { get; set; }
        [MaxLength(20)]
        [MinLength(8)]
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }
        //public bool IsAdmin { get; set; }
        //public bool IsActive { get; set; }
    }
}
