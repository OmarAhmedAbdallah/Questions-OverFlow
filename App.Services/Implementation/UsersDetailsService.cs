using App.Data.Models;
using App.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Implementation
{
    public class UsersDetailsService : IUsersDetailsService
    {
        private readonly ApplicationDbContext _context;


        
        public UsersDetailsService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<UserDetails> CheckLogin(string Email, string password)
        {
            //var userSubjects =  _context.Subjects.ToArray();

            var userdetails = await _context.userdetails
                      .SingleOrDefaultAsync(m => m.Email == Email && m.Passowrd == password);
            return userdetails;
        }

        public async Task<UserDetails> RegisterUserDetails(string name, string email, string password, string mobile)
        {
            UserDetails user = new UserDetails
            {
                Name = name,
                Email = email,
                Passowrd = password,
                Mobile = mobile
            };
            //var result = await userManager.CreateAsync(user, password);

            //if (result.Succeeded)
            //{
            //    await signInManager.SignInAsync(user, isPersistent: false);
            //}
            _context.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
