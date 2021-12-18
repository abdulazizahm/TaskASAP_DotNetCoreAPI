﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Repository.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //DBsets
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }



        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

       
    }
}
