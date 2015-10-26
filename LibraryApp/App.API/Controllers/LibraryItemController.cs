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
    public class LibraryItemController : CommonController
    {
        // GET: api/libraryitem?LibraryCode=MAR&SearchField=JavaScript&ItemsPerPage=60&Offset=0&SortOrder=0
        [HttpGet(Name = "GetLibraryItems")]
        public IEnumerable<LibraryItem> GetLibraryItems([FromQuery]MediatheekSimpleSearch search)
        {
            return _mediatheekService.GetLibraryItemsBySimpleSearch(search);
        }
        
        // GET api/libraryitem/MAR/693221
        [HttpGet("{libraryItemId:int}", Name = "GetLibraryItemById")]
        public IActionResult GetLibraryItemById(int libraryItemId)
        {
            var libraryItem = _mediatheekService.GetLibraryItemById("MAR", libraryItemId);
            if (libraryItem == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(libraryItem);
        }
    }
}
