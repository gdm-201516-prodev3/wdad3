using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using App.Models;

namespace App.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {   
        public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public Nullable<DateTime> UpdatedAt { get; set; }
		public Nullable<DateTime> DeletedAt { get; set; } 
        
        /* Virtual or Navigation Properties */
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }    
        public virtual ICollection<Post> Posts { get; set; }  
        public virtual ICollection<Category> Categories { get; set; }    
        public virtual ICollection<Comment> Comments { get; set; } 
        public virtual ICollection<FAQ> FAQs { get; set; }   
    }
}
