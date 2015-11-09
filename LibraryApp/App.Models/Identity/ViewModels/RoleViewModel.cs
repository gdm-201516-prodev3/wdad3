using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Identity.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(32, MinimumLength=4, ErrorMessage="The {0} must be at least {2} characters long.")]
        [Display(Name="Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
