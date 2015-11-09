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
    public class FAQsAsListViewComponent : ViewComponent
    {
        private readonly LibraryDbContext _libraryContext;
        
        public FAQsAsListViewComponent(LibraryDbContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public IViewComponentResult Invoke(int libraryId)
        {
            var model = GetFAQs(libraryId);
            
            return View(model);
        }

        public async Task<IViewComponentResult> InvokeAsync(int libraryId)
        {
            var model = await GetFAQsAsync(libraryId);
            return View(model);
        }

        private Task<IEnumerable<FAQ>> GetFAQsAsync(int libraryId)
        {
            return Task.FromResult(GetFAQs(libraryId));

        }
        private IEnumerable<FAQ> GetFAQs(int libraryId)
        {
            IEnumerable<FAQ> model = null;
            
            if(libraryId == 0)
            {
                model = _libraryContext.FAQs.Include(l => l.Library).OrderByDescending(o => o.Id).AsEnumerable();
            }
            else
            {
                model = _libraryContext.FAQs.Where(l => l.LibraryId == libraryId).OrderByDescending(o => o.Id).AsEnumerable();
            }
            
            return model;
        }
    }
}