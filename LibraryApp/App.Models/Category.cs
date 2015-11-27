using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using App.Models.Identity;

namespace App.Models
{
    public class Category : Item
    {
        public Category() : base()
        {
            
        }
        
        public Int16 Id { get; set; } 
        public string Name { get; set; } 
        
        
        /* Foreign Keys */
        public Nullable<Int16> ParentCategoryId { get; set; }
        public string UserId { get; set; }
        
        /* Virtual or Navigation Properties */
        public virtual Category ParentCategory { get; set; } 
        public virtual ICollection<Category> ChildCategories{ get; set; }
        public virtual ICollection<PostCategory> Posts { get; set; }  
        public virtual ApplicationUser User { get; set; } 
    }
}
