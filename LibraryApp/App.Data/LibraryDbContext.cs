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
        public DbSet<LibraryItemAction> LibraryItemActions { get; set; }
              
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
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Name).Required().HasColumnType("nvarchar(128)");
               l.Property(m => m.Code).Required().HasColumnType("char(3)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
               l.Property(m => m.Url).Required(false).HasColumnType("nvarchar(512)");
               
               l.Reference(m => m.User)
               .InverseCollection(m => m.Libraries)
               .ForeignKey(m => m.UserId);
            });
            
            modelBuilder.Entity<Post>(l =>
            {
               l.ToTable("Posts");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Title).Required().HasColumnType("nvarchar(128)");
               l.Property(m => m.Synopsis).Required().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
               l.Property(m => m.Body).Required().HasColumnType("nvarchar(65536)");
               
               // Library => 0 to many Posts
               l.Reference(m => m.Library)
               .InverseCollection(m => m.Posts)
               .ForeignKey(m => m.LibraryId);
               
               l.Reference(m => m.User)
               .InverseCollection(m => m.Posts)
               .ForeignKey(m => m.UserId);
               
            });
            
            modelBuilder.Entity<FAQ>(l =>
            {
               l.ToTable("Faqs");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Question).Required().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Answer).Required().HasColumnType("nvarchar(4096)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
               
               // Library => 0 to many FAQs
               l.Reference(m => m.Library)
               .InverseCollection(m => m.FAQs)
               .ForeignKey(m => m.LibraryId);
               
               l.Reference(m => m.User)
               .InverseCollection(m => m.FAQs)
               .ForeignKey(m => m.UserId);
               
            });
            
            modelBuilder.Entity<Category>(l =>
            {
               l.ToTable("Categories");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Name).Required().HasColumnType("nvarchar(255)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
               
               // Category => 0 to many Child categories
               l.Reference(m => m.ParentCategory)
               .InverseCollection(m => m.ChildCategories)
               .ForeignKey(m => m.ParentCategoryId);
               
               l.Reference(m => m.User)
               .InverseCollection(m => m.Categories)
               .ForeignKey(m => m.UserId);
               
            });
            
            modelBuilder.Entity<PostCategory>(l =>
            {
               l.ToTable("PostCategories");
               l.Key(m => new { m.PostId, m.CategoryId });
            });
            
            modelBuilder.Entity<Comment>(l =>
            {
               l.ToTable("Comments");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Body).Required().HasColumnType("nvarchar(65536)");
               l.Property(m => m.Description).Required(false).HasColumnType("nvarchar(1024)");
               
               // Comment => 0 to many Child comments
               l.Reference(m => m.ParentComment)
               .InverseCollection(m => m.ChildComments)
               .ForeignKey(m => m.ParentCommentId);
               
               // Post => 0 to many comments
               l.Reference(m => m.Post)
               .InverseCollection(m => m.Comments)
               .ForeignKey(m => m.PostId);
               
               l.Reference(m => m.User)
               .InverseCollection(m => m.Comments)
               .ForeignKey(m => m.UserId);
               
            });
            
            /*modelBuilder.Entity<LibraryItemAction>(l =>
            {
               l.ToTable("LibraryItemActions");
               l.Property(m => m.LibraryItemId).Required();
               l.Property(m => m.UserAgent).Required().HasColumnType("nvarchar(2056)");
               l.Property(m => m.Action).Required(true);
               l.Property(m => m.Rating).Required(false);
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               
               // ApplicationUser => 0 to many Actions
               l.Reference(m => m.User)
               .InverseCollection(m => m.Actions)
               .ForeignKey(m => m.UserId);
            })*/
            
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
