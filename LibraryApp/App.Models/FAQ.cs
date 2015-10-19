using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Identity;

namespace App.Models
{
    public class FAQ : Item
    {
        public FAQ() : base()
        {
            
        }
        
        public Int16 Id { get; set; } 
        public string Question { get; set; }
        public string Answer { get; set; }
        
        /* Foreign Keys */
        public Nullable<Int16> LibraryId { get; set; }
        public string UserId { get; set; }
        
        /* Virtual or Navigational Properties */
        public virtual Library Library { get; set; }    
        public virtual ApplicationUser User { get; set; }
    }
}
