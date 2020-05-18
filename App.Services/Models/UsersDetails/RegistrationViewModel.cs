using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Models.UsersDetails
{
    public class RegistrationViewModel
    {
        
        public string Name { get; set; }
        
        public string Mobile { get; set; }
       
        public string Email { get; set; }

        public string Password { get; set; }
       
        public string ConfirmPassword { get; set; }
    }
}
