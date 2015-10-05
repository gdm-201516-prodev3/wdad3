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
        private readonly LibraryDbContext _context;
        
        public LibrarySampleData(LibraryDbContext context)
        {
            _context = context;
        }
        
        public void InitializeData() 
        {
            CreateLibraries();    
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
        
        
    }
}
