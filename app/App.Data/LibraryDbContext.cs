using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using App.Models;

namespace App.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options):base(options)
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
            
            modelBuilder.Entity<PostCategory>(l =>
            {
                l.ToTable("PostCategories");
                l.Key(m => new { m.PostId, m.CategoryId });
            });
        }
    }
}
