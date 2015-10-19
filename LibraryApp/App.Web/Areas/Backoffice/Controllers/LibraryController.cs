using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using App.Models;

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
        public IActionResult Create()
        {
            var model = new Library();
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Library model)
        {
            try
            {
                if(!ModelState.IsValid)
                    throw new Exception("Mislukt");
                
                _libraryContext.Libraries.Add(model);
                _libraryContext.SaveChanges();    
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                
            }
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Library model)
        {
            try 
            {
                if(!ModelState.IsValid)
                    throw new Exception("De wijzigingen zijn niet");
                    
                var originalModel = _libraryContext.Libraries.FirstOrDefault(m => m.Id == model.Id);
                
                if(originalModel == null)
                    throw new Exception("De wijzigingen zijn niet");
                    
                originalModel.Name = model.Name;
                originalModel.Code = model.Code;
                originalModel.Description = model.Description;
                originalModel.UpdatedAt = null;
                
                _libraryContext.Libraries.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                int result = _libraryContext.SaveChanges();
                
                return RedirectToAction("Index");
            
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(model);
        }
    }
}
