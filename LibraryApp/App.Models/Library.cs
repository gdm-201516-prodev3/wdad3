using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Models.Identity;

namespace App.Models
{
    public class Library : Item
    {
        public Library() : base()
        {
            
        }
        
        [Key]
        public Int16 Id { get; set; } 
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }   
        
        /* Foreign Keys */
        public string UserId { get; set; }
        
        /* Virtual or Navigation Properties */
        public virtual ICollection<Post> Posts { get; set; }     
        public virtual ICollection<FAQ> FAQs { get; set; }  
        public virtual ApplicationUser User { get; set; }   
    }
}
