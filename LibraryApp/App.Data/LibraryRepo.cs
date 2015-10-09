using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public class LibraryRepo : ILibraryRepo
    {
        private readonly LibraryDbContext _db;

        public LibraryRepo(LibraryDbContext db)
        {
            _db = db;
        }

        public Library AddLibrary(Library library)
        {
            _db.Libraries.Add(library);

            if (_db.SaveChanges() > 0)
            {
                return library;
            }
            return null;
        }

        public bool DeleteLibrary(int libraryId)
        {
            var library = _db.Libraries.FirstOrDefault(c => c.Id == libraryId);
            if (library != null)
            {
                _db.Libraries.Remove(library);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public IEnumerable<Library> GetLibraries()
        {
            return _db.Libraries.AsEnumerable();
        }

        public Library GetLibrary(int libraryId)
        {
            return _db.Libraries.FirstOrDefault(c => c.Id == libraryId);
        }
    }
}
