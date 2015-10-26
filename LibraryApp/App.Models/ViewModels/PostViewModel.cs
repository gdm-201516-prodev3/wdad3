<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> d1e153b51b4503a390a1401fc746359f168e31e0
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
        public int[] SelectedCategoryIds { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}