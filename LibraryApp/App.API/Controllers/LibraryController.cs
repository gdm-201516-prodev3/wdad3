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
    public class LibraryController : CommonController
    {
        // GET: api/library
        [HttpGet(Name = "GetLibraries")]
        public IEnumerable<Library> GetLibraries()
        {
            return _libraryContext.Libraries.AsEnumerable();          
        }
        
        // GET api/library/5
        [HttpGet("{libraryId:int}", Name = "GetLibraryById")]
        public IActionResult GetLibraryById(int libraryId)
        {
            var model = _libraryContext.Libraries.FirstOrDefault(c => c.Id == libraryId);
            if (model == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(model);
        }
        
        // POST api/library
        [HttpPost(Name = "AddLibrary")]
        public IActionResult AddLibrary([FromBody]Library library)
        {
            if (!ModelState.IsValid)
            {
                HttpContext.Response.StatusCode = 400;
                return new ObjectResult(new LibraryStatus { Id = StatusTypes.ModelInvalid, Description = "Library model is invalid" + ModelState.ToString() });
            }
            else
            {
                _libraryContext.Libraries.Add(library);
                var addedLibrary = (_libraryContext.SaveChanges() > 0) ? library : null;

                if (addedLibrary != null)
                {
                    string url = Url.RouteUrl("GetLibraryById", new { libraryId = library.Id }, Request.Scheme, Request.Host.ToUriComponent());

                    HttpContext.Response.StatusCode = 201;
                    HttpContext.Response.Headers["Location"] = url;
                    return new ObjectResult(addedLibrary);
                }
                else
                {
                    HttpContext.Response.StatusCode = 400;
                    return new ObjectResult(new LibraryStatus { Id = StatusTypes.AddedFailure, Description = "Failed to save library" });
                }
            }
        }

        // PUT api/library/5
        [HttpPut("{libraryId:int}", Name = "UpdateLibrary")]
        public IActionResult UpdateLibrary(int libraryId, [FromBody]Library library)
        {
            var originalLibrary = _libraryContext.Libraries.FirstOrDefault(c => c.Id == libraryId);
            
            if (originalLibrary == null)
            {
                return HttpNotFound();
            }
            
            originalLibrary.Name = library.Name;
            originalLibrary.Code = library.Code;
            originalLibrary.Description = library.Description;
            
            _libraryContext.Entry(originalLibrary).State = EntityState.Modified;
            
            if (_libraryContext.SaveChanges() > 0)
            {
                return new HttpStatusCodeResult(204);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // DELETE api/library/5
        [HttpDelete("{libraryId:int}", Name = "DeleteLibrary")]
        public IActionResult DeleteLibrary(int libraryId)
        {
            var library = _libraryContext.Libraries.FirstOrDefault(c => c.Id == libraryId);
            
            if (library == null)
            {
                return HttpNotFound();
            }
                
            _libraryContext.Libraries.Remove(library);
            _libraryContext.Entry(library).State = EntityState.Deleted;
            
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
