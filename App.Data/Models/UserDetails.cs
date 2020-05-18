using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Models
{
    
    [Table("userdetails")]
    public class UserDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
        public string Passowrd { get; set; }
        public string Mobile { get; set; }
    }
}
