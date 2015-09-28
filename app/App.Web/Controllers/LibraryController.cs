using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Collections;
using App.Models;

namespace App.Web.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            var model = new Library();
            model.Name = "Mediatheek Mega Mariakerke";
            model.Description = "Hilde's playground";
            model.Code = "MAR";
            
            return View(model);
        }
    }
}
