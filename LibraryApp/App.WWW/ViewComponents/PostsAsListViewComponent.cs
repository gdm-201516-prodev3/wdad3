using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using App.Models;
using App.Models.ViewModels;
using App.Data;

namespace App.WWW.ViewComponents
{
    public class PostsAsListViewComponent : ViewComponent
    {
        private readonly LibraryDbContext _libraryContext;
        
        public PostsAsListViewComponent(LibraryDbContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public IViewComponentResult Invoke(int libraryId)
        {
            var model = GetPosts(libraryId);
            
            return View(model);
        }

        public async Task<IViewComponentResult> InvokeAsync(int libraryId)
        {
            var model = await GetPostsAsync(libraryId);
            return View(model);
        }

        private Task<IEnumerable<Post>> GetPostsAsync(int libraryId)
        {
            return Task.FromResult(GetPosts(libraryId));

        }
        private IEnumerable<Post> GetPosts(int libraryId)
        {
            IEnumerable<Post> model = null;
            
            if(libraryId == 0)
            {
                model = _libraryContext.Posts.Include(l => l.Library).OrderByDescending(o => o.Id).AsEnumerable();
            }
            else
            {
                model = _libraryContext.Posts.Where(l => l.LibraryId == libraryId).OrderByDescending(o => o.Id).AsEnumerable();
            }
            
            return model;
        }
    }
}