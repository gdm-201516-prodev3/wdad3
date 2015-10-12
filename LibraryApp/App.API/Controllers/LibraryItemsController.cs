using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Data;
using App.Models;
using App.Services;
using App.Services.Ahs;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    public class LibraryItemsController : Controller
    {
        [FromServices]
        public IMediatheekService _mediatheekService { get; set; }
        
        // GET: api/values
        [HttpGet(Name = "GetLibraryItems")]
        public IEnumerable<LibraryItem> GetLibraryItems()
        {
            var search = new MediatheekSimpleSearch() 
            {
                LibraryCode = "MAR",
                SearchField = "JavaScript",
                ItemsPerPage = 30,
                Offset = 0,
                SortOrder = MediatheekSortOrder.Title
            };
            return _mediatheekService.GetLibraryItemsBySimpleSearch(search);
        }
    }
}
