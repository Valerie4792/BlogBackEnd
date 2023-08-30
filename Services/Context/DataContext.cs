using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogBackEnd.Services.Context
{
    public class DataContext : DbContext
    {
       public DbSet<UserModel> UserInfo {get; set;}
        public DbSet<BlogitemModel> BlogInfo {get; set;}
        public DataContext(DbContextOptions options) : base(options) {
        }
        //function to create the tables themselves
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}