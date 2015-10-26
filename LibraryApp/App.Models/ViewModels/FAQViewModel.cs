using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class FAQViewModel
    {
        public FAQ FAQ { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
    }
}