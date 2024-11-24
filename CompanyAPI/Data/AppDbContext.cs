using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EntrepreneurModel> Entrepreneurs { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
    }
}