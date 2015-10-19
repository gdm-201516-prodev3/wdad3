using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public abstract class Item
    {
        public Item()
        {
            CreatedAt = DateTime.UtcNow;
        }
		
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public Nullable<DateTime> UpdatedAt { get; set; }
		public Nullable<DateTime> DeletedAt { get; set; }
        
    }
}
