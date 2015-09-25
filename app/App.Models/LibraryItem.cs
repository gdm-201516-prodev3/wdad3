using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LibraryItem : Item
    {
        public LibraryItem() : base()
        {
            
        }
        
        public Int32 Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Publisher { get; set; }
        public Nullable<Int16> Year { get; set; }
        public string ISBN { get; set; }
    }
}
