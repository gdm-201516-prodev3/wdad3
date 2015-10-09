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
        public DbSet<Post> Posts { get; set; }
        public DbSet<FAQ> FAQs { get; set; }        
        public DbSet<Category> Categories { get; set; }
              
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
               l.Property(m => m.Url).Required(false).HasColumnType("nvarchar(512)");
            });
            
            modelBuilder.Entity<Post>(l =>
            {
               l.ToTable("Posts");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Title).Required().HasColumnType("nvarchar(128)");
               l.Property(m => m.Synopsis).Required().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
               l.Property(m => m.Body).Required().HasColumnType("nvarchar(65536)");
            });
            
            modelBuilder.Entity<FAQ>(l =>
            {
               l.ToTable("Faqs");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Question).Required().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Answer).Required().HasColumnType("nvarchar(4096)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
            });
            
            modelBuilder.Entity<Category>(l =>
            {
               l.ToTable("Categories");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Name).Required().HasColumnType("nvarchar(255)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
            });
            
            modelBuilder.Entity<PostCategory>(l =>
            {
               l.ToTable("PostCategories");
               l.Key(m => new { m.PostId, m.CategoryId });
            });
            
        }
        
        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();

            var entries = this.ChangeTracker.Entries();

            // Add entry
            var entriesFiltered = entries.Where(e => e.State == EntityState.Added);
            foreach (var entry in entriesFiltered)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
            }

            // Update entry
            entriesFiltered = entries.Where(e => e.State == EntityState.Modified);
            foreach (var entry in entriesFiltered)
            {
                entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
