using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using App.Models;
using App.Models.ViewModels;

namespace App.WWW.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class PostController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Posts.Include(l => l.Library).Include(c => c.Categories).AsEnumerable().OrderByDescending(m => m.CreatedAt);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {                
            var filteredCategories = _libraryContext.Categories.Where(f => f.ParentCategory != null).Include(c => c.ParentCategory).AsEnumerable();
            
            var model = new PostViewModel 
            {
                Post = new Post(),
                Libraries = _libraryContext.Libraries.AsEnumerable()  ,
                Categories = new MultiSelectList(filteredCategories, "Id", "Name", null, "ParentCategory.Name")
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
                
                var entityEntry = _libraryContext.Posts.Add(model.Post);
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be saved!");
                }
                
                var post = entityEntry.Entity;
                
                if(model.SelectedCategoryIds != null && model.SelectedCategoryIds.Count() > 0) 
                {
                    var postsCategories = new List<PostCategory>();
                    foreach(var categoryId in model.SelectedCategoryIds)
                    {
                        postsCategories.Add(new PostCategory{
                           PostId = post.Id,
                           CategoryId = categoryId 
                        });
                    }
                    post.Categories = postsCategories;
                    
                    _libraryContext.Posts.Attach(post);
                    _libraryContext.Entry(post).State = EntityState.Modified;
                
                    if (_libraryContext.SaveChanges() == 0)
                    {
                        throw new Exception("The Post model could not be saved!");
                    }
                }
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
                
                var filteredCategories = _libraryContext.Categories.Where(f => f.ParentCategory != null).Include(c => c.ParentCategory).AsEnumerable();
                viewModel = new PostViewModel 
                {
                    Post = model.Post,
                    Libraries = _libraryContext.Libraries.AsEnumerable(),
                    SelectedCategoryIds = model.SelectedCategoryIds,
                    Categories = new MultiSelectList(filteredCategories, "Id", "Name", model.SelectedCategoryIds, "ParentCategory.Name")
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
            
            var model = _libraryContext.Posts.Include(c => c.Categories).FirstOrDefault(m => m.Id == id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            Int16[] ids = null;
            if(model.Categories != null && model.Categories.Count > 0){
                ids = new Int16[model.Categories.Count];
                int i = 0;
                foreach (var postCategory in model.Categories)
                {
                    ids[i] = postCategory.CategoryId;
                    i++;
                }
            }

            var filteredCategories = _libraryContext.Categories.Where(f => f.ParentCategory != null).Include(c => c.ParentCategory).AsEnumerable();
            var viewModel = new PostViewModel
            {
                Post = model,
                Libraries = _libraryContext.Libraries.AsEnumerable(),
                SelectedCategoryIds = ids,
                Categories = new MultiSelectList(filteredCategories, "Id", "Name", ids, "ParentCategory.Name")
            };
                        
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostViewModel model)
        {
            PostViewModel viewModel = null;
            try 
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Post model is not valid!");
                    
                var originalModel = _libraryContext.Posts.Include(p => p.Categories).FirstOrDefault(m => m.Id == model.Post.Id);
                
                if(originalModel == null)
                    throw new Exception("The existing Post: " + model.Post.Title + " doesn't exists anymore!");
                    
                originalModel.Title = model.Post.Title;
                originalModel.Synopsis = model.Post.Synopsis;
                originalModel.Description = model.Post.Description;
                originalModel.Body = model.Post.Body;
                originalModel.LibraryId = model.Post.LibraryId;
                if(originalModel.Categories != null) 
                {
                    originalModel.Categories.Clear();
                }
                else
                {
                    originalModel.Categories = new List<PostCategory>();
                }
               
                var entityEntry = _libraryContext.Posts.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Post model could not be saved!");
                }
                
                if(model.SelectedCategoryIds != null && model.SelectedCategoryIds.Count() > 0) 
                {
                    foreach(var categoryId in model.SelectedCategoryIds)
                    {
                        originalModel.Categories.Add(new PostCategory{
                           PostId = originalModel.Id,
                           CategoryId = categoryId 
                        });
                    }
                }
                
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
                
                var filteredCategories = _libraryContext.Categories.Where(f => f.ParentCategory != null).Include(c => c.ParentCategory).AsEnumerable();
                viewModel = new PostViewModel
                {
                    Post = model.Post,
                    Libraries = _libraryContext.Libraries.AsEnumerable(),
                    SelectedCategoryIds = model.SelectedCategoryIds,
                    Categories = new MultiSelectList(filteredCategories, "Id", "Name", model.SelectedCategoryIds, "ParentCategory.Name")
                };     
            }
            return View(viewModel);
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