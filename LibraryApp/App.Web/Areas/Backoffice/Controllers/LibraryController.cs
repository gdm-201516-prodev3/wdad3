using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace App.Web.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class LibraryController : CommonController
    {
        public IActionResult Index()
        {
            var model = _libraryContext.Libraries.AsEnumerable().OrderBy(m => m.Name);
            
            return View(model);
        }
    }
}
