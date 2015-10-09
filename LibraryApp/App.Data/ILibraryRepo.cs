using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public interface ILibraryRepo
    {
        IEnumerable<Library> GetLibraries();
        Library GetLibrary(int libraryId);
        Library AddLibrary(Library library);
        bool DeleteLibrary(int libraryId);
    }
}
