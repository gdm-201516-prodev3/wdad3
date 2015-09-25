using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Library : Item
    {
        public Library() : base()
        {
            
        }
        
        public Int16 Id { get; set; } 
        public string Name { get; set; }
        public string Code { get; set; }
        
        /* Navigational or Virtual Properties */
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<FAQ> FAQs { get; set; }            
    }
}
