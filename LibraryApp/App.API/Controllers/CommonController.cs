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
    public abstract class CommonController : Controller
    {
        [FromServices]
        public LibraryDbContext _libraryContext { get; set; }
        
        [FromServices]
        public IMediatheekService _mediatheekService { get; set; } 
    }
}
