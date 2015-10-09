using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Models;
using App.Data;

namespace App.Web.Controllers
{
    public class LibraryController : CommonController
    {
        public IActionResult Index()
        {
            var models = _libraryRepo.GetLibraries();
            return View(models);
        }
        
        public IActionResult Details(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(400);    
            }
            
            var model = _libraryRepo.GetLibrary(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
