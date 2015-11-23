using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using App.Data;
using App.Models;
using App.Models.Identity;
using App.Services;
using App.Services.Ahs;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : CommonController
    {
        // GET: api/post
        [HttpGet(Name = "GetUsers")]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _libraryContext.Users.Include(c => c.Profile).AsEnumerable();          
        }
    }
}
