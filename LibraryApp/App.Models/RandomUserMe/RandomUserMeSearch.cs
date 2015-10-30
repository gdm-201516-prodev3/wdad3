using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.RandomUserMe
{
    public class RandomUserMeSearch
    {
        public string Nationality { get; set; }
        public string Seed { get; set; }
        public string Version { get; set; }
        public ICollection<RandomUserUser> results { get; set; }
    }
}
