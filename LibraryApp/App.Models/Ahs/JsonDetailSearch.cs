using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Ahs
{
    public class JsonDetailSearch
    {
        public string act { get; set; }
        public Int32 totaal { get; set; }
        public Int16 offset { get; set; }
        public LibraryItem res { get; set; }
    }
}
