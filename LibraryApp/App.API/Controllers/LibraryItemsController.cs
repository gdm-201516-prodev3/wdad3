using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Data;
using App.Models;
using App.Models.Ahs;
using App.Services;
using App.Services.Ahs;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    public class LibraryItemsController : CommonController
    {
        // GET: api/libraryitem?LibraryCode=MAR&SearchField=JavaScript&ItemsPerPage=60&Offset=0&SortOrder=0
        [HttpGet(Name = "GetLibraryItems")]
        public IEnumerable<LibraryItem> GetLibraryItems([FromQuery]MediatheekSimpleSearch search)
        {
            return _mediatheekService.GetLibraryItemsBySimpleSearch(search);
        }
        
        // GET api/libraryitem/MAR/693221
        [HttpGet("{libraryCode}/{libraryItemId}", Name = "GetLibraryItemById")]
        public IActionResult GetLibraryItemById(string libraryCode, int libraryItemId)
        {
            var libraryItem = _mediatheekService.GetLibraryItemById(libraryCode, libraryItemId);
            if (libraryItem == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(libraryItem);
        }
        
        // GET: api/libraryitem/arrivals/?LibraryCode=MAR&DaysAge=20&ItemsPerPage=60&Offset=0&SortOrder=0
        [HttpGet("Arrivals", Name = "GetLibraryItemsArrivals")]
        public IEnumerable<LibraryItem> GetLibraryItemsArrivals([FromQuery]MediatheekArrivalsSearch search)
        {
            return _mediatheekService.GetLibraryItemsByArrivalsSearch(search);
        }
    }
}
