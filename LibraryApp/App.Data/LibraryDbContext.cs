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
        public DbSet<Profile> Profiles { get; set; }
              
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
            
            modelBuilder.Entity<ApplicationUser>(l =>
            {  
               l.HasOne(m => m.Profile).WithOne().ForeignKey<Profile>(m => m.UserId);
            });
            
            modelBuilder.Entity<Profile>(l =>
            {  
               l.ToTable("Profiles");
               l.HasKey(m => m.UserId);
               l.Property(m => m.FirstName).IsRequired().HasColumnType("nvarchar(64)");
               l.Property(m => m.SurName).IsRequired().HasColumnType("nvarchar(128)");
            });
            
            modelBuilder.Entity<Library>(l =>
            {
               l.ToTable("Libraries");
               l.HasKey(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.Name).IsRequired().HasColumnType("nvarchar(128)");
               l.Property(m => m.Code).IsRequired().HasColumnType("char(3)");
               l.Property(m => m.Description).IsRequired(false).HasColumnType("nvarchar(1024)");
               l.Property(m => m.Url).IsRequired(false).HasColumnType("nvarchar(512)");
               
               l.HasOne(m => m.User)
               .WithMany(m => m.Libraries)
               .ForeignKey(m => m.UserId);
            });
            
            modelBuilder.Entity<Post>(l =>
            {
               l.ToTable("Posts");
               l.HasKey(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.Title).IsRequired().HasColumnType("nvarchar(128)");
               l.Property(m => m.Synopsis).IsRequired().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Description).IsRequired(false).HasColumnType("nvarchar(1024)");
               l.Property(m => m.Body).IsRequired().HasColumnType("nvarchar(65536)");
               
               // Library => 0 to many Posts
               l.HasOne(m => m.Library)
               .WithMany(m => m.Posts)
               .ForeignKey(m => m.LibraryId);
               
               l.HasOne(m => m.User)
               .WithMany(m => m.Posts)
               .ForeignKey(m => m.UserId);
               
            });
            
            modelBuilder.Entity<FAQ>(l =>
            {
               l.ToTable("Faqs");
               l.HasKey(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.Question).IsRequired().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Answer).IsRequired().HasColumnType("nvarchar(4096)");
               l.Property(m => m.Description).IsRequired(false).HasColumnType("nvarchar(1024)");
               
               // Library => 0 to many FAQs
               l.HasOne(m => m.Library)
               .WithMany(m => m.FAQs)
               .ForeignKey(m => m.LibraryId);
               
               l.HasOne(m => m.User)
               .WithMany(m => m.FAQs)
               .ForeignKey(m => m.UserId);
               
            });
            
            modelBuilder.Entity<Category>(l =>
            {
               l.ToTable("Categories");
               l.HasKey(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.Name).IsRequired().HasColumnType("nvarchar(255)");
               l.Property(m => m.Description).IsRequired(false).HasColumnType("nvarchar(1024)");
               
               // Category => 0 to many Child categories
               l.HasOne(m => m.ParentCategory)
               .WithMany(m => m.ChildCategories)
               .ForeignKey(m => m.ParentCategoryId);
               
               l.HasOne(m => m.User)
               .WithMany(m => m.Categories)
               .ForeignKey(m => m.UserId);
               
            });
            
            modelBuilder.Entity<PostCategory>(l =>
            {
               l.ToTable("PostCategories");
               l.HasKey(m => new { m.PostId, m.CategoryId });
            });
            
            modelBuilder.Entity<Comment>(l =>
            {
               l.ToTable("Comments");
               l.HasKey(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).IsRequired(false).HasColumnType("datetime");
               l.Property(m => m.Body).IsRequired().HasColumnType("nvarchar(65536)");
               l.Property(m => m.Description).IsRequired(false).HasColumnType("nvarchar(1024)");
               
               // Comment => 0 to many Child comments
               l.HasOne(m => m.ParentComment)
               .WithMany(m => m.ChildComments)
               .ForeignKey(m => m.ParentCommentId);
               
               // Post => 0 to many comments
               l.HasOne(m => m.Post)
               .WithMany(m => m.Comments)
               .ForeignKey(m => m.PostId);
               
               l.HasOne(m => m.User)
               .WithMany(m => m.Comments)
               .ForeignKey(m => m.UserId);
               
            });
            
            /*modelBuilder.Entity<LibraryItemAction>(l =>
            {
               l.ToTable("LibraryItemActions");
               l.Property(m => m.LibraryItemId).IsRequired();
               l.Property(m => m.UserAgent).IsRequired().HasColumnType("nvarchar(2056)");
               l.Property(m => m.Action).IsRequired(true);
               l.Property(m => m.Rating).IsRequired(false);
               l.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime").ValueGeneratedOnAdd();
               
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
                TrySetProperty(entry.Entity, "CreatedAt", DateTime.UtcNow);
            }

            // Update entry
            entriesFiltered = entries.Where(e => e.State == EntityState.Modified);
            foreach (var entry in entriesFiltered)
            {
                TrySetProperty(entry.Entity, "UpdatedAt", DateTime.UtcNow);
            }

            return base.SaveChanges();
        }
        
        private void TrySetProperty(object obj, string p, object value)
        {
            var prop = obj.GetType().GetProperty(p);
            if(prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
            }
        }
    }
}
