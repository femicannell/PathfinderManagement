using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PathfinderManagement.Models;

namespace PathfinderManagement.Data
{
    public class PfDbContext : DbContext
    {
        // Here we add in all the tables we are using.
        public DbSet<Counsellors> Counsellors { get; set; }
        public DbSet<Pathfinders> Pathfinders { get; set; }
        // We need 2 constructors, one is empty, and the other injects in DbContextOptions
        public PfDbContext(DbContextOptions<PfDbContext> options)
        : base(options)
        {
        }
        public PfDbContext()
        {
        }
    }
}