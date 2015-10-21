using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Models;
using App.Models.ViewModels;
using App.Data;

namespace App.Web.Areas.Backoffice.ViewComponents
{
    public class AmountForEntityViewComponent : ViewComponent
    {
        private readonly LibraryDbContext _libraryContext;
        
        public AmountForEntityViewComponent(LibraryDbContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public IViewComponentResult Invoke(string entityType)
        {
            var model = GetAmountForEntity(entityType);
            return View(model);
        }

        public async Task<IViewComponentResult> InvokeAsync(string entityType)
        {
            var model = await GetAmountForEntityAsync(entityType);
            return View(model);
        }

        private Task<AmountForEntity> GetAmountForEntityAsync(string entityType)
        {
            return Task.FromResult(GetAmountForEntity(entityType));

        }
        private AmountForEntity GetAmountForEntity(string entityType)
        {
            var amount = 0;
            var entitytype = "Entity";
            var name = "Entity";
            var pluralizeName = "Entities";
            
            switch(entityType)
            {
                case "Library":
                    amount = _libraryContext.Libraries.AsEnumerable().Count();
                    entitytype = "Library";
                    name = "Mediatheek";
                    pluralizeName = "Mediatheken";
                    break;
                case "Post":
                    amount = _libraryContext.Posts.AsEnumerable().Count();
                    entitytype = "Post";
                    name = "Post";
                    pluralizeName = "Posts";
                    break;
                case "Category":
                    amount = _libraryContext.Categories.AsEnumerable().Count();
                    entitytype = "Category";
                    name = "Categorie";
                    pluralizeName = "Categorieën";
                    break;
                case "FAQ":
                    amount = _libraryContext.FAQs.AsEnumerable().Count();
                    entitytype = "FAQ";
                    name = "FAQ";
                    pluralizeName = "FAQs";
                    break;
                case "User":
                    amount = _libraryContext.Users.AsEnumerable().Count();
                    entitytype = "User";
                    name = "Gebruiker";
                    pluralizeName = "Gebruikers";
                    break;
                case "Role":
                    amount = _libraryContext.Roles.AsEnumerable().Count();
                    entitytype = "Role";
                    name = "Rol";
                    pluralizeName = "Rollen";
                    break;
            }
            
            var model = new AmountForEntity()
            {
                Amount = amount,
                EntityType = entitytype,
                Name = name,
                PluralizeName = pluralizeName
            };

            return model;
        }

    }
}