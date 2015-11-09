using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace App.WWW.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class HomeController : CommonController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
