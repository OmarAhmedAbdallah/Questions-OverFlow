using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models
{
    
    [Table("userdetails")]
    public class UserDetails
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^01[0-2]{1}[0-9]{8}", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }

        public string AvatarPath { get; set; } = "";
        public List<Post> posts { get; set; }
    }
}
