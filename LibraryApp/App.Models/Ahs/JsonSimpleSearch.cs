using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Ahs
{
    public class JsonSimpleSearch
    {
        public string act { get; set; }
        public int totaal { get; set; }
        public int offset { get; set; }
        public ICollection<JsonLibraryItem> res { get; set; }
    }
}
