using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Category : Item
    {
        public Category() : base()
        {
            
        }
        
        public Int16 Id { get; set; } 
        public string Name { get; set; } 
        /* Virtual Properties */
        public virtual ICollection<PostCategory> Posts { get; set; }   
    }
}
