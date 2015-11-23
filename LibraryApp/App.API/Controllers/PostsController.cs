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
    public class PostsController : CommonController
    {
        // GET: api/post
        [HttpGet(Name = "GetPosts")]
        public IActionResult GetPosts()
        {
            return new ObjectResult(_libraryContext.Posts.Include(c => c.Categories).AsEnumerable());          
        }
        
        // GET api/post/5
        [HttpGet("{postId:int}", Name = "GetPostById")]
        public IActionResult GetPostById(int postId)
        {
            var model = _libraryContext.Posts.FirstOrDefault(c => c.Id == postId);
            if (model == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(model);
        }
        
        // POST api/post
        [HttpPost(Name = "AddPost")]
        public IActionResult AddPost([FromBody]Post post)
        {
            if (!ModelState.IsValid)
            {
                HttpContext.Response.StatusCode = 400;
                return new ObjectResult(new LibraryStatus { Id = StatusTypes.ModelInvalid, Description = "Post model is invalid" + ModelState.ToString() });
            }
            else
            {
                _libraryContext.Posts.Add(post);
                var addedPost = (_libraryContext.SaveChanges() > 0) ? post : null;

                if (addedPost != null)
                {
                    string url = Url.RouteUrl("GetPostById", new { postId = post.Id }, Request.Scheme, Request.Host.ToUriComponent());

                    HttpContext.Response.StatusCode = 201;
                    HttpContext.Response.Headers["Location"] = url;
                    return new ObjectResult(addedPost);
                }
                else
                {
                    HttpContext.Response.StatusCode = 400;
                    return new ObjectResult(new LibraryStatus { Id = StatusTypes.AddedFailure, Description = "Failed to save Post" });
                }
            }
        }

        // PUT api/post/5
        [HttpPut("{postId:int}", Name = "UpdatePost")]
        public IActionResult UpdatePost(int postId, [FromBody]Post post)
        {
            var originalPost = _libraryContext.Posts.FirstOrDefault(c => c.Id == postId);
            
            if (originalPost == null)
            {
                return HttpNotFound();
            }
            
            originalPost.Title = post.Title;
            originalPost.Description = post.Description;
            originalPost.Synopsis = post.Synopsis;
            originalPost.Body = post.Body;
            
            _libraryContext.Entry(originalPost).State = EntityState.Modified;
            
            if (_libraryContext.SaveChanges() > 0)
            {
                return new HttpStatusCodeResult(204);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // DELETE api/post/5
        [HttpDelete("{postId:int}", Name = "DeletePost")]
        public IActionResult DeletePost(int postId)
        {
            var post = _libraryContext.Posts.FirstOrDefault(c => c.Id == postId);
            
            if (post == null)
            {
                return HttpNotFound();
            }
                
            _libraryContext.Posts.Remove(post);
            _libraryContext.Entry(post).State = EntityState.Deleted;
            
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
