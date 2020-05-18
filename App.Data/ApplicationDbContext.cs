using System;
using System.Collections.Generic;
using System.Text;
using App.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Web.Data
{
   
    public class ApplicationDbContext : DbContext
    {

        
        public DbSet<UserDetails> userdetails { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<Article> articles { get; set; }

        //public DbSet<Subjects> Subjects { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }


        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
