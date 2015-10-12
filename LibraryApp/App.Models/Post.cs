using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Post : Item
    {
        public Post() : base()
        {
            
        }
        
        public Int32 Id { get; set; } 
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Body { get; set; }
        
        /* Foreign Keys */
        public Nullable<Int16> LibraryId { get; set; }
        
        /* Virtual or Navigational Properties */
        public virtual Library Library { get; set; } 
        public virtual ICollection<PostCategory> Categories { get; set; }      
    }
}
