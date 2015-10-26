using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using App.Models;
using App.Models.Ahs;
using App.Models.Ahs.ViewModels;
using App.Data;

namespace App.Web.Controllers
{
    public class LibraryItemController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new MediatheekSimpleSearchViewModel
            {
                MediatheekSimpleSearch = new MediatheekSimpleSearch
                {
                    LibraryCode = "MAR",
                    ItemsPerPage = 30,
                    Offset = 0 
                }
            };
            
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Index(MediatheekSimpleSearchViewModel searchModel)
        {
            var resultModel = _mediatheekService.GetLibraryItemsBySimpleSearch(searchModel.MediatheekSimpleSearch);
            
            if (this.Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_LibraryItemsPagedList", resultModel);
            }
            
            return View(searchModel);
        }
    }
}
