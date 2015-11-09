using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using App.Models;
using App.Models.ViewModels;
using App.Data;

namespace App.WWW.ViewComponents
{
    public class PostViewComponent : ViewComponent
    {
        private readonly LibraryDbContext _libraryContext;
        
        public PostViewComponent(LibraryDbContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public IViewComponentResult Invoke(int postId)
        {
            var model = GetPost(postId);
            
            return View(model);
        }

        public async Task<IViewComponentResult> InvokeAsync(int postId)
        {
            var model = await GetPostAsync(postId);
            return View(model);
        }

        private Task<Post> GetPostAsync(int postId)
        {
            return Task.FromResult(GetPost(postId));

        }
        private Post GetPost(int postId)
        {
            var model = _libraryContext.Posts.FirstOrDefault(p => p.Id == postId);

            return model;
        }
    }
}