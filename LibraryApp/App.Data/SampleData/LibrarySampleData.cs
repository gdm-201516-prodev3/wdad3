using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using App.Data;
using App.Models;
using App.Models.Identity;
using App.Models.RandomUserMe;
using App.Services.RandomUserMe;

namespace App.Data.SampleData
{
    public class LibrarySampleData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LibraryDbContext _context;
        private readonly IRandomUserMeService _randomUserMeService;
        
        public LibrarySampleData(UserManager<ApplicationUser> userManager, LibraryDbContext context, IRandomUserMeService randomUserMeService)
        {
            _userManager = userManager;
            _context = context;
            _randomUserMeService = randomUserMeService;
        }
        
        public async void InitializeData() 
        {
            await CreateUsers();// 1. Create Users
            await CreateLibraries();// 2. Create Users 
            await CreatePosts();// 3. Create Posts   
            CreateFAQs();
            CreateCategories();
        }
        
        private async Task<bool> CreateUsers() 
        {
            if(_context.Users == null || _context.Users.Count() == 0)
            {
                var randomUsers = _randomUserMeService.GetRandomUsers(100);
                foreach(var randomUserUser in randomUsers)
                {
                    var user = new ApplicationUser 
                    { 
                        UserName = randomUserUser.User.Username, 
                        Email = randomUserUser.User.Email
                    };
                    var result = await _userManager.CreateAsync(user, "Slaam_1888");
                    
                    if(!result.Succeeded)
                        return false;
                    
                    var profile = new Profile
                    {
                        FirstName = randomUserUser.User.Name.FirstName,
                        SurName = randomUserUser.User.Name.SurName,
                        PictureLarge = randomUserUser.User.Picture.Large,
                        PictureMedium = randomUserUser.User.Picture.Medium,
                        PictureSmall = randomUserUser.User.Picture.Small,
                        UserId = _context.Users.Where(m => m.UserName == randomUserUser.User.Username).FirstOrDefault().Id
                    };
                    
                    _context.Profiles.Add(profile);
                    var resultProfile = await _context.SaveChangesAsync();
                    if(resultProfile == 0)
                        return false;
                }
            }
            return true;
        }
        
        private async Task<bool> CreateLibraries() 
        {
            if(_context.Libraries == null || _context.Libraries.Count() == 0)
            {
                _context.Libraries.Add(new Library()
                {
                    Name = "Alle Mediatheken",
                    Code = "ART",
                    Description = "Alle Mediatheken",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Kantienberg",
                    Code = "KAN",
                    Description = "Domein: Gezondheidszorg - Handelswetenschappen en bedrijfskunde",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-kantienberg"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Kattenberg",
                    Code = "KAT",
                    Description = "Domein: Onderwijs",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-kattenberg-en-mediatheekpunt-bps"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Mariakerke",
                    Code = "MAR",
                    Description = "Domein: Grafische en digitale media",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-mariakerke"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Sint-Amandsberg",
                    Code = "SAB",
                    Description = "Domein: Opvoeding en onderwijs van het jonge kind",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-sint-amandsberg"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Sint-Annaplein",
                    Code = "SAT",
                    Description = "Domein: Sociaal werk",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-sint-annaplein"
                });
                
                if(await _context.SaveChangesAsync() == 0)
                    return false;
            }
            return false;
        }
        
        private async Task<bool> CreatePosts() 
        {
            if(_context.Posts == null || _context.Posts.Count() == 0)
            {
                var libraries = _context.Libraries.AsEnumerable();
                var random = new Random();
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                _context.Posts.Add(new Post()
                {
                    Title = "Finse overheid publiceert 'onbreekbaar'-emoji van Nokia 3310",
                    Synopsis = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Description = "Finland heeft naar eigen zeggen als eerste land ter wereld een reeks eigen emoji's gepubliceerd. De reeks bevat onder andere emoticons van een headbanger, een sauna en de Nokia 3310. De emoji van de telefoon is bedoeld om aan te geven dat iets onbreekbaar is.",
                    Body = @"
                    <p>Vanaf 1 december zal er een collectie van meer dan dertig Finse emoji's verschijnen. Iedere dag wordt een nieuw plaatje gepresenteerd in een kerstkalender met 24 hokjes. De kalender wordt zichtbaar op een website, maar er zullen ook apps verschijnen. We zijn vooral niet serieus geweest bij het maken van deze emoji's. Hopelijk zullen ze niet alleen onze vreemde, maar ook onze sterke eigenschappen openbaren, verklaart het ministerie.</p><p>De emoji's zijn een initiatief van het Finse ministerie van Buitenlandse Zaken om het land te promoten. De icoontjes moeten Finse emoties uitdrukken. Als voorproefje zijn de drie emoji's Sauna, Headbanger en Unbreakable te bekijken.</p>",
                    Library = libraries.ElementAt(random.Next(0, libraries.Count() - 1))
                });
                
                if(await _context.SaveChangesAsync() == 0)
                    return false;
            }
            return true;
        }
        
        private void CreateFAQs() 
        {
            if(_context.FAQs == null || _context.FAQs.Count() == 0)
            {
                _context.FAQs.Add(new FAQ()
                {
                    Question = "Wat is het verschil met het secundair onderwijs? ",
                    Description = "",
                    Answer = @"
                    <p><strong>Je moet zelfstandiger werken</strong>.<br>
	De opleiding verwacht dat je op een actieve en zelfstandige manier je studies aanpakt. Bovendien zal je merken dat het tempo in de lessen hoog ligt en dat je heel wat meer leerstof op korte tijd moet verwerken. Je moet meer dan in het secundair onderwijs je taken en opdrachten goed plannen. Niet alle leerstof verwerf je via contactonderwijs. Dit betekent zeker niet dat je aan je lot wordt overgelaten! Je wordt hierin begeleid door de docenten en indien nodig ook door de leercoach.</p>"
                });
                
                _context.SaveChanges();
            }
        }
        
        private void CreateCategories() 
        {
            if(_context.Categories == null || _context.Categories.Count() == 0)
            {
                _context.Categories.Add(new Category()
                {
                    Name = "Webtechnologie",
                    Description = "Webtechnologie"
                });
                
                _context.Categories.Add(new Category()
                {
                    Name = "HTML",
                    Description = "HTML",
                    ParentCategoryId = 1
                });
                
                _context.SaveChanges();
            }
        }
    }
}
