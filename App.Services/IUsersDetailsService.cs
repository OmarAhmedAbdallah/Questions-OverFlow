using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IUsersDetailsService
    {
        public Task<UserDetails> CheckLogin(string Email,string password);
        public Task<UserDetails> RegisterUserDetails(string name, string email, string password, string mobile);
    }
}
