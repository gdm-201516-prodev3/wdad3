using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Identity;

namespace App.Models
{
    public class Comment : Item
    {
        public Comment() : base()
        {
            
        }
        
        public Int32 Id { get; set; } 
        public string Body { get; set; } 
        
        
        /* Foreign Keys */
        public Int32 PostId { get; set; }
        public Nullable<Int32> ParentCommentId { get; set; }
        public string UserId { get; set; }
        
        /* Virtual or Navigation Properties */
        public virtual Post Post { get; set; } 
        public virtual Comment ParentComment { get; set; } 
        public virtual ICollection<Comment> ChildComments{ get; set; }  
        public virtual ApplicationUser User { get; set; }
    }
}
