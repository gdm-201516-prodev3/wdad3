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
    public class CategoryController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Categories.Include(l => l.ParentCategory).AsEnumerable().OrderBy(m => m.Name);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryViewModel
            {
                Category = new Category(),
                Categories = _libraryContext.Categories.AsEnumerable().OrderBy(m => m.Name)
            };
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel model)
        {
            CategoryViewModel viewModel = null;
            try
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Category model is not valid!");
                
                _libraryContext.Categories.Add(model.Category);
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Category model could not be saved!");
                }   
                
                //Success(CreateMessage(ControllerActionType.Create, "library", model.Name), true);
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
                
                viewModel = new CategoryViewModel
                {
                    Category = model.Category,
                    Categories = _libraryContext.Categories.AsEnumerable().OrderBy(m => m.Name)
                };
            }
            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Edit(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            
            var model = _libraryContext.Categories.FirstOrDefault(m => m.Id == id);
            
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            var viewModel = new CategoryViewModel
            {
                Category = model,
                Categories = _libraryContext.Categories.AsEnumerable().Where(m => m.Id != id).OrderBy(m => m.Name)
            };
            
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel model)
        {
            try 
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Category model is not valid!");
                    
                var originalModel = _libraryContext.Categories.FirstOrDefault(m => m.Id == model.Category.Id);
                
                if(originalModel == null)
                    throw new Exception("The existing Category: " + model.Category.Name + " doesn't exists anymore!");
                    
                originalModel.Name = model.Category.Name;
                originalModel.Description = model.Category.Description;
                originalModel.ParentCategoryId = model.Category.ParentCategoryId;
                
                _libraryContext.Categories.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Category model could not be saved!");
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
                var originalModel = _libraryContext.Categories.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Library with id: " + id + " doesn't exists anymore!");

                _libraryContext.Categories.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Deleted;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Category model could not be saved!");
                } 

                var msg = CreateMessage(ControllerActionType.Delete, "category", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Delete, "category", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftDelete(Int16 id)
        {
            try
            {
                var originalModel = _libraryContext.Categories.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Category with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = DateTime.Now;
                _libraryContext.Categories.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Category model could not be soft deleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftDelete, "category", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftDelete, "category", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftUnDelete(Int16 id)
        {
            try
            {
                var originalModel = _libraryContext.Categories.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Category with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = null;
                _libraryContext.Categories.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Category model could not be soft undeleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "category", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "category", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }
            }
        }
    }
}