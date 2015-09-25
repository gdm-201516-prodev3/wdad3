using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class PostCategory
    {
        public PostCategory()
        {
            
        }
        
        /* Foreign Keys */
        public Int32 PostId { get; set; }
        public Int16 CategoryId { get; set; }
        
        /* Navigational or Virtual Properties */
        public virtual Post Post { get; set; }           
        public virtual Category Category { get; set; }  
    }
}
