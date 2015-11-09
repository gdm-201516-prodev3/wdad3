using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Ahs
{
    public class JsonDetailSearch
    {
        public string act { get; set; }
        public int totaal { get; set; }
        public int offset { get; set; }
        public LibraryItem res { get; set; }
    }
}
