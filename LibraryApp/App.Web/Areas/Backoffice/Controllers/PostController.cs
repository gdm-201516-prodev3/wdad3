using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using App.Models;
using App.Models.ViewModels;

namespace App.Web.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class PostController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Posts.Include(l => l.Library).AsEnumerable().OrderByDescending(m => m.CreatedAt);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new PostViewModel 
            {
                Post = new Post(),
                Libraries = _libraryContext.Libraries.AsEnumerable()    
            };
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostViewModel model)
        {
            PostViewModel viewModel = null;
            try
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Post model is not valid!");
                
                _libraryContext.Posts.Add(model.Post);
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be saved!");
                }   
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
                
                viewModel = new PostViewModel 
                {
                    Post = new Post(),
                    Libraries = _libraryContext.Libraries.AsEnumerable()    
                };
            }
            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Edit(Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            
            var post = _libraryContext.Posts.FirstOrDefault(m => m.Id == id);
            if(post == null)
                throw new Exception("Post does not exists!");
            
            var model = new PostViewModel
            {
                Post = post,
                Libraries = _libraryContext.Libraries.AsEnumerable() 
            };
            
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostViewModel model)
        {
            try 
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Post model is not valid!");
                    
                var originalModel = _libraryContext.Posts.FirstOrDefault(m => m.Id == model.Post.Id);
                
                if(originalModel == null)
                    throw new Exception("The existing Post: " + model.Post.Title + " doesn't exists anymore!");
                    
                originalModel.Title = model.Post.Title;
                originalModel.Synopsis = model.Post.Synopsis;
                originalModel.Description = model.Post.Description;
                originalModel.Body = model.Post.Body;
                originalModel.LibraryId = model.Post.LibraryId;
                
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
