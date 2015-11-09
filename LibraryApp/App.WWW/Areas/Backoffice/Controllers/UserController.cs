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
    public class UserController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = _libraryContext.Users.Include(l => l.Profile).AsEnumerable().OrderByDescending(m => m.CreatedAt);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_ListPartial", model);
            }
            
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                var originalModel = _libraryContext.Users.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing User with id: " + id + " doesn't exists anymore!");

                _libraryContext.Users.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Deleted;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The User model could not be saved!");
                } 

                var msg = CreateMessage(ControllerActionType.Delete, "user", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Delete, "user", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftDelete(string id)
        {
            try
            {
                var originalModel = _libraryContext.Users.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing User with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = DateTime.Now;
                _libraryContext.Users.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The User model could not be soft deleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftDelete, "user", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftDelete, "user", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
        }
        
        [HttpPost]
        public IActionResult SoftUnDelete(string id)
        {
            try
            {
                var originalModel = _libraryContext.Users.FirstOrDefault(m => m.Id == id);
                
                if(originalModel == null)
                    throw new Exception("The existing User with id: " + id + " doesn't exists anymore!");

                originalModel.DeletedAt = null;
                _libraryContext.Users.Attach(originalModel);
                _libraryContext.Entry(originalModel).State = EntityState.Modified;
                
                if (_libraryContext.SaveChanges() == 0)
                {
                   throw new Exception("The User model could not be soft undeleted!");
                } 

                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "user", id);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 1, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.SoftUnDelete, "user", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Lock(string id)
        {
            try
            {
                var model = await _applicationUserManager.FindByIdAsync(id);

                if (model == null)
                    throw new Exception("User does not exist!");

                var now = DateTime.Now;
                now = now.AddMonths(1);

                if (await _applicationUserManager.GetLockoutEnabledAsync(model) == false)
                    throw new Exception("Lockout is not enabled!");

                var result = await _applicationUserManager.SetLockoutEndDateAsync(model, new DateTimeOffset(now));

                if (result.Succeeded)
                {
                    var msg = CreateMessage(ControllerActionType.Lock, "user", model.UserName);

                    if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { state = 1, id = model.Id, message = msg });
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    throw new Exception("Can't lock the user!");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Lock, "user", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> UnLock(string id)
        {
            try
            {
                var model = await _applicationUserManager.FindByIdAsync(id);

                if (model == null)
                    throw new Exception("User does not exist!");

                if (await _applicationUserManager.GetLockoutEnabledAsync(model) == false)
                    throw new Exception("Lockout is not enabled!");

                var result = await _applicationUserManager.SetLockoutEndDateAsync(model, DateTimeOffset.MinValue);

                if (result.Succeeded)
                {
                    var msg = CreateMessage(ControllerActionType.Lock, "user", model.UserName);

                    if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { state = 1, id = model.Id, message = msg });
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    throw new Exception("Can't unlock the user!");
                }

            }
            catch (Exception ex)
            {
                var msg = CreateMessage(ControllerActionType.Lock, "user", id, ex);

                if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { state = 0, id = id, message = msg });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
        }
    }
}