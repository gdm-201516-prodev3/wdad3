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
    public class LibraryController : CommonController
    {
        // GET: api/values
        [HttpGet(Name = "GetLibraries")]
        public IEnumerable<Library> GetLibraries()
        {
            return _libraryRepo.GetLibraries();           
        }
    }
}
