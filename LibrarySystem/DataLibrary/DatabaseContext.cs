
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace DataLibrary
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Borrowers> Borrowers { get; set; }
        public DbSet<Lended> Lended { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
