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
                    Description = "Alle Mediatheken"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Kantienberg",
                    Code = "KAN",
                    Description = "Mediatheek Kantienberg"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Kattenberg",
                    Code = "KAT",
                    Description = "Mediatheek Kattenberg"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Mariakerke",
                    Code = "MAR",
                    Description = "Mediatheek Mariakerke"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Sint-Amandsberg",
                    Code = "SAB",
                    Description = "Mediatheek Sint-Amandsberg"
                });
                
                _context.Libraries.Add(new Library()
                {
                    Name = "Mediatheek Sint-Annaplein",
                    Code = "SAT",
                    Description = "Mediatheek Sint-Annaplein"
                });
                
                _context.SaveChanges();
            }
        }
        
        
    }
}
