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
    public class FAQsController : CommonController
    {
        // GET: api/faq
        [HttpGet(Name = "GetFAQs")]
        public IEnumerable<FAQ> GetFAQs()
        {
            return _libraryContext.FAQs.AsEnumerable();          
        }
        
        // GET api/faq/5
        [HttpGet("{faqId:int}", Name = "GetFAQById")]
        public IActionResult GetFAQById(int faqId)
        {
            var model = _libraryContext.FAQs.FirstOrDefault(c => c.Id == faqId);
            if (model == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(model);
        }
        
        // POST api/faq
        [HttpPost(Name = "AddFAQ")]
        public IActionResult AddFAQ([FromBody]FAQ faq)
        {
            if (!ModelState.IsValid)
            {
                HttpContext.Response.StatusCode = 400;
                return new ObjectResult(new LibraryStatus { Id = StatusTypes.ModelInvalid, Description = "FAQ model is invalid" + ModelState.ToString() });
            }
            else
            {
                _libraryContext.FAQs.Add(faq);
                var addedFAQ = (_libraryContext.SaveChanges() > 0) ? faq : null;

                if (addedFAQ != null)
                {
                    string url = Url.RouteUrl("GetFAQById", new { faqId = faq.Id }, Request.Scheme, Request.Host.ToUriComponent());

                    HttpContext.Response.StatusCode = 201;
                    HttpContext.Response.Headers["Location"] = url;
                    return new ObjectResult(addedFAQ);
                }
                else
                {
                    HttpContext.Response.StatusCode = 400;
                    return new ObjectResult(new LibraryStatus { Id = StatusTypes.AddedFailure, Description = "Failed to save FAQ" });
                }
            }
        }

        // PUT api/faq/5
        [HttpPut("{faqId:int}", Name = "UpdateFAQ")]
        public IActionResult UpdateFAQ(int faqId, [FromBody]FAQ faq)
        {
            var originalFAQ = _libraryContext.FAQs.FirstOrDefault(c => c.Id == faqId);
            
            if (originalFAQ == null)
            {
                return HttpNotFound();
            }
            
            originalFAQ.Question = faq.Question;
            originalFAQ.Answer = faq.Answer;
            originalFAQ.Description = faq.Description;
            
            _libraryContext.Entry(originalFAQ).State = EntityState.Modified;
            
            if (_libraryContext.SaveChanges() > 0)
            {
                return new HttpStatusCodeResult(204);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // DELETE api/faq/5
        [HttpDelete("{faqId:int}", Name = "DeleteFAQ")]
        public IActionResult DeleteFAQ(int faqId)
        {
            var faq = _libraryContext.FAQs.FirstOrDefault(c => c.Id == faqId);
            
            if (faq == null)
            {
                return HttpNotFound();
            }
                
            _libraryContext.FAQs.Remove(faq);
            _libraryContext.Entry(faq).State = EntityState.Deleted;
            
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
