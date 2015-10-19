using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Utilities;
using App.Models.Identity;

namespace App.Models
{
    public class LibraryItemAction
    {
        [Key]
        public Int32 LibraryItemId { get; set; }
        public string UserId { get; set; }
        public string UserAgent { get; set; }
        public LibraryItemAction Action { get; set; }
        public Nullable<Int16> Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        /* Virtual or Navigational Properties */
        public virtual ApplicationUser User { get; set; }
    }
    
    public enum LibraryItemActions
    {
        View = 0,
        Like = 1,
        Dislike = 2,
        Whish = 3,
        Rate = 4
    }
}