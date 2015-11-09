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
    public class LibrariesAsListViewComponent : ViewComponent
    {
        private readonly LibraryDbContext _libraryContext;
        
        public LibrariesAsListViewComponent(LibraryDbContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public IViewComponentResult Invoke()
        {
            var model = GetLibraries();
            
            return View(model);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await GetLibrariesAsync();
            return View(model);
        }

        private Task<IEnumerable<Library>> GetLibrariesAsync()
        {
            return Task.FromResult(GetLibraries());

        }
        private IEnumerable<Library> GetLibraries()
        {
            var model = _libraryContext.Libraries.AsEnumerable();

            return model;
        }
    }
}