using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using App.Models.Identity;
using App.Models.Identity.ViewModels;

namespace App.WWW.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class RoleController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Roles.AsEnumerable().OrderByDescending(m => m.CreatedAt);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);
        }
        
        public ActionResult Create()
        {
            var model = new RoleViewModel();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Role is not valid");

                var role = new ApplicationRole { Name = model.Name, Description = model.Description};
                var result = await _applicationRoleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    throw new Exception("Can't create the role!");
                }
                
                var msg = CreateMessage(ControllerActionType.Create, "role", model.Name);
                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Create, "role", model.Name, ex);
                return View(model);
            }
        }
        
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            
            var model = _libraryContext.Roles.FirstOrDefault(m => m.Id == id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            
            var viewModel = new RoleViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
                        
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoleViewModel model)
        {
            RoleViewModel viewModel = null;
            try 
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Role model is not valid!");
                    
                var originalModel = _libraryContext.Roles.FirstOrDefault(m => m.Id == model.Id);
                
                if(originalModel == null)
                    throw new Exception("The existing Role: " + model.Name + " doesn't exists anymore!");
                    
                originalModel.Name = model.Name;
                originalModel.Description = model.Description;
                
                
                _libraryContext.Roles.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Role model could not be saved!");
                }
                
                return RedirectToAction("Index");
            
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
                
                viewModel = new RoleViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description
                };    
            }
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                var originalModel = _libraryContext.Roles.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Role with id: " + id + " doesn't exists anymore!");

                _libraryContext.Roles.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Deleted;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Role model could not be saved!");
                } 

                var msg = CreateMessage(ControllerActionType.Delete, "role", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Role");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Delete, "role", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Role");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftDelete(string id)
        {
            try
            {
                var originalModel = _libraryContext.Roles.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Role with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = DateTime.Now;
                _libraryContext.Roles.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Role model could not be soft deleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftDelete, "role", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Role");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftDelete, "role", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Role");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftUnDelete(string id)
        {
            try
            {
                var originalModel = _libraryContext.Roles.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing Role with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = null;
                _libraryContext.Roles.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The Role model could not be soft undeleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "role", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Role");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "role", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "Role");
                }
            }
        }
    }
}