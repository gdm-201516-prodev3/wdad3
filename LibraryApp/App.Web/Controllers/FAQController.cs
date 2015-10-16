using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Models;
using App.Data;

namespace App.Web.Controllers
{
    public class FAQController : CommonController
    {
        public IActionResult Index()
        {
            var models = _libraryContext.FAQs.AsEnumerable();
            return View(models);
        }
    }
}
