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
    public class PostController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Posts.AsEnumerable().OrderByDescending(m => m.CreatedAt);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Post();
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post model)
        {
            try
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Post model is not valid!");
                
                _libraryContext.Posts.Add(model);
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be saved!");
                }   
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Edit(Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            
            var model = _libraryContext.Posts.FirstOrDefault(m => m.Id == id);
            
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post model)
        {
            try 
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Post model is not valid!");
                    
                var originalModel = _libraryContext.Posts.FirstOrDefault(m => m.Id == model.Id);
                
                if(originalModel == null)
                    throw new Exception("The existing Post: " + model.Title + " doesn't exists anymore!");
                    
                originalModel.Title = model.Title;
                originalModel.Synopsis = model.Synopsis;
                originalModel.Description = model.Description;
                originalModel.Body = model.Body;
                
                _libraryContext.Posts.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be saved!");
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
        public IActionResult Delete(Int32? id)
        {
            try
            {
                var originalModel = _libraryContext.Posts.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Post with id: " + id + " doesn't exists anymore!");

                _libraryContext.Posts.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Deleted;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be saved!");
                } 

                var msg = CreateMessage(ControllerActionType.Delete, "post", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Post");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Delete, "post", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Post");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftDelete(Int16 id)
        {
            try
            {
                var originalModel = _libraryContext.Posts.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Post with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = DateTime.Now;
                _libraryContext.Posts.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be soft deleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftDelete, "post", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Post");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftDelete, "post", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Post");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftUnDelete(Int32? id)
        {
            try
            {
                var originalModel = _libraryContext.Posts.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Post with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = null;
                _libraryContext.Posts.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be soft undeleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "post", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Post");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "post", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Post");
                }
            }
        }
    }
}
