using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
