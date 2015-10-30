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
		
		public Int32 PostId { get; set; }
        public Int16 CategoryId { get; set; }
		public virtual Post Post{ get; set; }
		public virtual Category Category{ get; set; }
    }
}
