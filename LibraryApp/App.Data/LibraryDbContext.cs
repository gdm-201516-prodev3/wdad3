using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using App.Models;
using App.Models.Identity;

namespace App.Data
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Library> Libraries { get; set; }
              
        public LibraryDbContext() : base()
        {
            
        }   
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Library>(l =>
            {
               l.ToTable("Libraries");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Name).Required().HasColumnType("nvarchar(128)");
               l.Property(m => m.Code).Required().HasColumnType("char(3)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
            });
            
        }
    }
}
