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
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Libraries.AsEnumerable().OrderBy(m => m.Name);
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Edit(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            
            var model = _libraryContext.Libraries.FirstOrDefault(m => m.Id == id);
            
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
    }
}
