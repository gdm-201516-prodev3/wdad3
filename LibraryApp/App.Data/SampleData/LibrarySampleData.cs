using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models;

namespace App.Data.SampleData
{
    public class LibrarySampleData
    {
        private readonly ILibraryDbContext _context;
        
        public LibrarySampleData(LibraryDbContext context)
        {
            _context = context;
        }
        
        public void InitializeData() 
        {
            CreateLibraries(); 
            CreatePosts();   
            CreateFAQs();
            CreateCategories();
        }
        
        private void CreateLibraries() 
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
                    Description = "Mediatheek Kantienberg",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-kantienberg"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Kattenberg",
                    Code = "KAT",
                    Description = "Mediatheek Kattenberg",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-kattenberg-en-mediatheekpunt-bps"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Mariakerke",
                    Code = "MAR",
                    Description = "Mediatheek Mariakerke",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-mariakerke"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Sint-Amandsberg",
                    Code = "SAB",
                    Description = "Mediatheek Sint-Amandsberg",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-sint-amandsberg"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Sint-Annaplein",
                    Code = "SAT",
                    Description = "Mediatheek Sint-Annaplein",
                    Url = "http://arteveldehogeschool.be/studeren/mediatheken/mediatheek-sint-annaplein"
                });
                
                _context.SaveChanges();
            }
        }
        
        private void CreatePosts() 
        {
            if(_context.Posts == null || _context.Posts.Count() == 0)
            {
                _context.Posts.Add(new Post()
                {
                    Title = "Herbekijk het openingscollege Björn Soenens",
                    Synopsis = "ART",
                    Description = "Op vrijdag 18 september gaf Björn Soenens, VRT-hoofdredacteur van Het Journaal, zijn kijk op constructieve journalistiek tijdens het allereerste openingscollege van de opleiding Bachelor in de journalistiek aan de Arteveldehogeschool.",
                    Body = @"
                    <p>Op vrijdag 18 september gaf Björn Soenens, VRT-hoofdredacteur van Het Journaal, zijn kijk op constructieve journalistiek tijdens het allereerste openingscollege van de opleiding Bachelor in de journalistiek aan de Arteveldehogeschool.</p>
                    <p>“Ook jullie generatie zoekt diepgang” en “Het is onze journalistieke taak om de ruis van het internet te halen” zijn maar enkele van de krachtige oneliners uit de lezing die hij gaf. (Her)bekijk hieronder zijn pleidooi en enkele foto’s van het openingscollege.</p>                    
                    <p>Met dank aan de studentenvertegenwoordigers van Journalistiek. Meer info: https://www.facebook.com/groups/Stuverjournalistiek/
                    Op vrijdag 18 september gaf Björn Soenens, VRT-hoofdredacteur van Het Journaal, zijn kijk op constructieve journalistiek tijdens het allereerste openingscollege van de opleiding Bachelor in de journalistiek aan de Arteveldehogeschool.</p>                    
                    <p>“Ook jullie generatie zoekt diepgang” en “Het is onze journalistieke taak om de ruis van het internet te halen” zijn maar enkele van de krachtige oneliners uit de lezing die hij gaf. (Her)bekijk hieronder zijn pleidooi en enkele foto’s van het openingscollege.</p>                    
                    <p>Met dank aan de studentenvertegenwoordigers van Journalistiek. Meer info: https://www.facebook.com/groups/Stuverjournalistiek/
                    </p>"
                });
                
                _context.SaveChanges();
            }
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
