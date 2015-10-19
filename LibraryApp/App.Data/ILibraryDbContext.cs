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
    public interface ILibraryDbContext : IDisposable
    {
        DbSet<Library> Libraries { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<FAQ> FAQs { get; set; }        
        DbSet<Category> Categories { get; set; }  
        
        int SaveChanges();
    }
}
