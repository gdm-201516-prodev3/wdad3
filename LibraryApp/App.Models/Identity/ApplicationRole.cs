using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Models.Identity
{
    public class ApplicationRole : IdentityRole
    {   
        public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public Nullable<DateTime> UpdatedAt { get; set; }
		public Nullable<DateTime> DeletedAt { get; set; }    
    }
}