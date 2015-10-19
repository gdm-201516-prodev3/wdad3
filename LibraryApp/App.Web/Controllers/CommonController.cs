using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using App.Models;
using App.Data;
using App.Services.Ahs;

namespace App.Web.Controllers
{
    public abstract class CommonController : Controller
    {
        [FromServices]
        public LibraryDbContext _libraryContext { get; set; }
        
        [FromServices]
        public IMediatheekService _mediatheekService { get; set; }
    }
}
