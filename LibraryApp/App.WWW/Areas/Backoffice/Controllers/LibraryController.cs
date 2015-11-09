using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using App.Models;

namespace App.WWW.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class LibraryController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Libraries.AsEnumerable().OrderBy(m => m.Name);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
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
                    throw new Exception("The Library model is not valid!");
                
                _libraryContext.Libraries.Add(model);
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Library model could not be saved!");
                }   
                
                //Success(CreateMessage(ControllerActionType.Create, "library", model.Name), true);
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
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
                    throw new Exception("The Library model is not valid!");
                    
                var originalModel = _libraryContext.Libraries.FirstOrDefault(m => m.Id == model.Id);
                
                if(originalModel == null)
                    throw new Exception("The existing Library: " + model.Name + " doesn't exists anymore!");
                    
                originalModel.Name = model.Name;
                originalModel.Code = model.Code;
                originalModel.Description = model.Description;
                originalModel.UpdatedAt = null;
                
                _libraryContext.Libraries.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Library model could not be saved!");
                } 
                
                return RedirectToAction("Index");
            
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Delete(Int16 id)
        {
            try
            {
                var originalModel = _libraryContext.Libraries.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Library with id: " + id + " doesn't exists anymore!");

                _libraryContext.Libraries.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Deleted;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Library model could not be saved!");
                } 

                var msg = CreateMessage(ControllerActionType.Delete, "library", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Library");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Delete, "library", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Library");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftDelete(Int16 id)
        {
            try
            {
                var originalModel = _libraryContext.Libraries.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Library with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = DateTime.Now;
                _libraryContext.Libraries.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Library model could not be soft deleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftDelete, "library", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Library");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftDelete, "library", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Library");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftUnDelete(Int16 id)
        {
            try
            {
                var originalModel = _libraryContext.Libraries.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Library with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = null;
                _libraryContext.Libraries.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Library model could not be soft undeleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "library", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Library");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "library", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Library");
                }
            }
        }
    }
}
