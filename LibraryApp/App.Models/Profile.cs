using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using App.Models.Identity;

namespace App.Models
{
    public class Profile
    {  
        [Key]
        public string UserId { get; set; } 
        public string FirstName { get; set; }
		public string SurName { get; set; }
        
        /* Virtual or Navigation Properties */
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
