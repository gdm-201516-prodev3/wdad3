using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using App.Models;
using App.Models.ViewModels;

namespace App.WWW.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class FAQController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.FAQs.Include(l => l.Library).AsEnumerable().OrderByDescending(m => m.CreatedAt);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new FAQViewModel 
            {
                FAQ = new FAQ(),
                Libraries = _libraryContext.Libraries.AsEnumerable()    
            };
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FAQViewModel model)
        {
            FAQViewModel viewModel = null;
            try
            {
                if(!ModelState.IsValid)
                    throw new Exception("The FAQ model is not valid!");
                
                _libraryContext.FAQs.Add(model.FAQ);
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The FAQ model could not be saved!");
                }   
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
                
                viewModel = new FAQViewModel 
                {
                    FAQ = new FAQ(),
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
            
            var model = _libraryContext.FAQs.FirstOrDefault(m => m.Id == id);
            
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            var viewModel = new FAQViewModel
            {
                FAQ = model,
                Libraries = _libraryContext.Libraries.AsEnumerable() 
            };
            
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FAQViewModel model)
        {
            try 
            {
                if(!ModelState.IsValid)
                    throw new Exception("The FAQ model is not valid!");
                    
                var originalModel = _libraryContext.FAQs.FirstOrDefault(m => m.Id == model.FAQ.Id);
                
                if(originalModel == null)
                    throw new Exception("The existing Post: " + model.FAQ.Question + " doesn't exists anymore!");
                    
                originalModel.Question = model.FAQ.Question;
                originalModel.Answer = model.FAQ.Answer;
                originalModel.Description = model.FAQ.Description;
                originalModel.LibraryId = model.FAQ.LibraryId;
                
                _libraryContext.FAQs.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The FAQ model could not be saved!");
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
        public IActionResult Delete(Int16? id)
        {
            try
            {
                var originalModel = _libraryContext.FAQs.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing FAQ with id: " + id + " doesn't exists anymore!");

                _libraryContext.FAQs.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Deleted;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The FAQ model could not be saved!");
                } 

                var msg = CreateMessage(ControllerActionType.Delete, "faq", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "FAQ");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Delete, "faq", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "FAQ");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftDelete(Int16? id)
        {
            try
            {
                var originalModel = _libraryContext.FAQs.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing FAQ with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = DateTime.Now;
                _libraryContext.FAQs.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The FAQ model could not be soft deleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftDelete, "faq", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "FAQ");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftDelete, "faq", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "FAQ");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftUnDelete(Int16? id)
        {
            try
            {
                var originalModel = _libraryContext.FAQs.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing FAQ with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = null;
                _libraryContext.FAQs.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The FAQ model could not be soft undeleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "faq", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "FAQ");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "faq", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "FAQ");
                }
            }
        }
    }
}