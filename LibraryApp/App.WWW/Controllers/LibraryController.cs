using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace App.WWW.Controllers
{
    public class LibraryController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Details(Int16 id)
        {
            var model = _libraryContext.Libraries.FirstOrDefault(p => p.Id == id);
            
            return View(model);
        }
        
    }
}