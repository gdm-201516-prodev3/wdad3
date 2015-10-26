using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
    }
}