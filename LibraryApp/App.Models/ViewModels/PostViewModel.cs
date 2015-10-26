using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;

namespace App.Models.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
        public IEnumerable<Int16> SelectedCategoryIds { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}