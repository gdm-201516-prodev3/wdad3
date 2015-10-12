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
    public class LibraryItemController : CommonController
    {
        // GET: api/values
        [HttpGet(Name = "GetLibraryItems")]
        public IEnumerable<LibraryItem> GetLibraryItems()
        {
            var search = new MediatheekSimpleSearch() 
            {
                LibraryCode = "MAR",
                SearchField = "CSS",
                ItemsPerPage = 30,
                Offset = 0,
                SortOrder = MediatheekSortOrder.Relavance
            };
            return _mediatheekService.GetLibraryItemsBySimpleSearch(search);
        }
    }
}
