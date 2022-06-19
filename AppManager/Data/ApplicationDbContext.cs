using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AppManager.Models;

namespace AppManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppManager.Models.ItemModel> ItemModel { get; set; }
        public DbSet<AppManager.Models.ActivityModel> ActivityModel { get; set; }
    }
}
