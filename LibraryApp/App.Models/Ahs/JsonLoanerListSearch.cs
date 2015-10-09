using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Models.Ahs
{
    public class JsonLoanerListSearch
    {
        public string stat { get; set; }
        public ICollection<LoanerList> res { get; set; }
    }
}
