using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using PagedList;
using App.Models;
using App.Models.Ahs;
using App.Services.Ahs;

namespace App.WWW.ViewComponents
{
    public class LibraryItemsArrivalsAsListViewComponent : ViewComponent
    {
        private readonly IMediatheekService _mediatheekService;
        
        public LibraryItemsArrivalsAsListViewComponent(IMediatheekService mediatheekService)
        {
            _mediatheekService = mediatheekService;
        }
        
        public IViewComponentResult Invoke()
        {
            var model = GetLibraryItemsArrivals();
            return View(model);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await GetLibraryItemsArrivalsAsync();
            return View(model);
        }

        private Task<IPagedList<LibraryItem>> GetLibraryItemsArrivalsAsync()
        {
            return Task.FromResult(GetLibraryItemsArrivals());

        }
        private IPagedList<LibraryItem> GetLibraryItemsArrivals()
        {
            var mediatheekArrivalSearch = new MediatheekSimpleSearch
            {
                LibraryCode = "MAR",
                SearchField = "css",
                ItemsPerPage = 20,
                Offset = 0,
                SortOrder = MediatheekSortOrder.Relavance
            };
            
            var model = _mediatheekService.GetLibraryItemsBySimpleSearch(mediatheekArrivalSearch);
            return model;
        }
    }
}