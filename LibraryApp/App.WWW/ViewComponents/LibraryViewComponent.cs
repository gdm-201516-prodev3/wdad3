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
    public class LibraryViewComponent : ViewComponent
    {
        private readonly LibraryDbContext _libraryContext;
        
        public LibraryViewComponent(LibraryDbContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public IViewComponentResult Invoke(int libraryId)
        {
            var model = GetLibrary(libraryId);
            
            return View(model);
        }

        public async Task<IViewComponentResult> InvokeAsync(int libraryId)
        {
            var model = await GetLibraryAsync(libraryId);
            return View(model);
        }

        private Task<Library> GetLibraryAsync(int libraryId)
        {
            return Task.FromResult(GetLibrary(libraryId));

        }
        private Library GetLibrary(int libraryId)
        {
            var model = _libraryContext.Libraries.FirstOrDefault(p => p.Id == libraryId);

            return model;
        }
    }
}