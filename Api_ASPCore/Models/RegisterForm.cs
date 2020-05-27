using System;
using System.ComponentModel.DataAnnotations;

namespace Api_ASPCore.Models
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }
        
        [Required]
        [EmailAddress]
        [MaxLength(384)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Passwd { get; set; }
        
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }


    }
}