using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace App.WWW.Controllers
{
    public class FAQController : CommonController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}