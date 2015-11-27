using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Ahs
{
    public enum MediatheekSortOrder
    {
        [Display(Name = "Relevantie")]
        Relavance = 0,
        [Display(Name = "Titel")]
        Title = 2,
        [Display(Name = "Auteur")]
        Author = 7,
        [Display(Name = "Titel nummer")]
        SetNumberTitle = 8,
        [Display(Name = "Jaar Auteur")]
        AuthorYear = 16,
        [Display(Name = "Nummer")]
        SetSetNumber = 18,
        [Display(Name = "Selectie volgorde")]
        SelectionOrder = 99
    }

    public class MediatheekSimpleSearch
    {
        public string LibraryCode { get; set; }
        public string SearchField { get; set; }
        public int ItemsPerPage { get; set; }
        public int Offset { get; set; }
        public MediatheekSortOrder SortOrder { get; set; } 
    }
    
    public class MediatheekArrivalsSearch
    {
        public string LibraryCode { get; set; }
        public int DaysAge { get; set; }
        public int ItemsPerPage { get; set; }
        public int Offset { get; set; }
        public MediatheekSortOrder SortOrder { get; set; }
    }

    public class MediatheekAdvancedSearch
    {
        public string LibraryCode { get; set; }
        public MediatheekAdvancedSearchBool SearchBool { get; set; }
        public int Material = 0;
        public string YearReach { get; set; }
        public int ItemsPerPage { get; set; }
        public int Offset { get; set; }
        public MediatheekSortOrder SortOrder { get; set; }
        public ICollection<MediatheekAdvancedSearchArray> SearchArrays { get; set; }
    }

    public class MediatheekAdvancedSearchArray
    {
        public string SearchField { get; set; }
        public MediatheekAdvancedSearchCondition SearchCondition { get; set; }
        public MediatheekAdvancedTruncationMethod TruncationMethod { get; set; }
        public override string ToString()
        {
            return (int)SearchCondition + "-" + (int)TruncationMethod + "-" + SearchField;
        }
    }

    public enum MediatheekAdvancedSearchBool
    {
        AND,
        OR
    }

    public enum MediatheekAdvancedSearchCondition
    {
        Title = 270,
        Author = 7,
        Tags = 8,
        SISO = 28,
        Genre = 27,
        Magazine = 10,
        Type = 101,
        Language = 34,
        Year = 363,
        PlaceCharacteristic = 13
    }

    public enum MediatheekAdvancedTruncationMethod
    {
        Contains = 3,
        StartsWith = 2,
        Equals = 1,
        Reach = 0,
        In = 1,
        Before = 6,
        After = 5
    }
   
}   