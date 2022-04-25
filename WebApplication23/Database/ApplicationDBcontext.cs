using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication23.Controllers;

namespace WebApplication23.Database
{
    public class ApplicationDBcontext : DbContext
    {
        public DbSet<LoginViewModel> Users { get; set; }
        public DbSet<ThemViewModel> them { get; set; }
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
