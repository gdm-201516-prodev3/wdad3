using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using App.Data;
using App.Models;
using App.Services;
using App.Services.Ahs;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : CommonController
    {
        // GET: api/category
        [HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            return _libraryContext.Categories.Include(p => p.ChildCategories).AsEnumerable();          
        }
        
        // GET api/category/5
        [HttpGet("{categoryId:int}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var model = _libraryContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (model == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(model);
        }
        
        // POST api/category
        [HttpPost(Name = "AddCategory")]
        public IActionResult AddCategory([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                HttpContext.Response.StatusCode = 400;
                return new ObjectResult(new LibraryStatus { Id = StatusTypes.ModelInvalid, Description = "Category model is invalid" + ModelState.ToString() });
            }
            else
            {
                _libraryContext.Categories.Add(category);
                var addedCategory = (_libraryContext.SaveChanges() > 0) ? category : null;

                if (addedCategory != null)
                {
                    string url = Url.RouteUrl("GetCategoryById", new { categoryId = category.Id }, Request.Scheme, Request.Host.ToUriComponent());

                    HttpContext.Response.StatusCode = 201;
                    HttpContext.Response.Headers["Location"] = url;
                    return new ObjectResult(addedCategory);
                }
                else
                {
                    HttpContext.Response.StatusCode = 400;
                    return new ObjectResult(new LibraryStatus { Id = StatusTypes.AddedFailure, Description = "Failed to save Category" });
                }
            }
        }

        // PUT api/category/5
        [HttpPut("{categoryId:int}", Name = "UpdateCategory")]
        public IActionResult UpdateCategory(int categoryId, [FromBody]Category category)
        {
            var originalCategory = _libraryContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            
            if (originalCategory == null)
            {
                return HttpNotFound();
            }
            
            originalCategory.Name = category.Name;
            originalCategory.Description = category.Description;
            originalCategory.ParentCategory = category.ParentCategory;
            
            _libraryContext.Entry(originalCategory).State = EntityState.Modified;
            
            if (_libraryContext.SaveChanges() > 0)
            {
                return new HttpStatusCodeResult(204);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // DELETE api/category/5
        [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var category = _libraryContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            
            if (category == null)
            {
                return HttpNotFound();
            }
                
            _libraryContext.Categories.Remove(category);
            _libraryContext.Entry(category).State = EntityState.Deleted;
            
            if (_libraryContext.SaveChanges() > 0)
            {
                return new HttpStatusCodeResult(204);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
