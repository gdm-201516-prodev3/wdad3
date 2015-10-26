using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class AmountForEntityViewModel
    {
        public int Amount { get; set; }
        public string EntityType { get; set; }
        public string Name { get; set; }
        public string PluralizeName  { get; set; }
    }
}
