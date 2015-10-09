using System.Collections.Generic;
using PagedList;
using App.Models;
using App.Models.Ahs;
using App.Services.Utilities;

namespace App.Services.Ahs
{
    public interface IMediatheekService
    {
        LibraryItem GetLibraryItemById(string libraryCode, int? libraryItemId);
        IPagedList<LibraryItem> GetLibraryItemsByAdvancedSearch(MediatheekAdvancedSearch search);
        IPagedList<LibraryItem> GetLibraryItemsByArrivalsSearch(MediatheekArrivalsSearch search);
        IPagedList<LibraryItem> GetLibraryItemsBySimpleSearch(MediatheekSimpleSearch search);
        ICollection<LoanerList> GetLoanerLists(int? loanerId);
    }
}