using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Models;
using App.Data;
using App.Services.Ahs;

namespace App.Web.Controllers
{
    public class CommonController : Controller
    {
        [FromServices]
        public ILibraryRepo _libraryRepo { get; set; }
        
        [FromServices]
        public IPostRepo _postRepo { get; set; }
        
        [FromServices]
        public IFAQRepo _faqRepo { get; set; }
        
        [FromServices]
        public IMediatheekService _mediatheekService { get; set; }
    }
}
