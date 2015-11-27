using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using App.Models.Identity;

namespace App.Models
{
    [JsonObject(IsReference = true)]
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
        public string UserId { get; set; }
 
        /* Virtual or Navigational Properties */
        public virtual Library Library { get; set; } 
        public virtual ICollection<PostCategory> Categories { get; set; }  
        public virtual ICollection<Comment> Comments { get; set; } 
        public virtual ApplicationUser User { get; set; }    
    }
}
