using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Models;
using App.Data;
using App.Services.Ahs;

namespace App.Web.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public abstract class CommonController : Controller
    {
        [FromServices]
        public ILibraryDbContext _libraryContext { get; set; }
        
        [FromServices]
        public IMediatheekService _mediatheekService { get; set; }
    }
}