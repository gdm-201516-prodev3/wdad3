using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PagedList;
using App.Models;
using App.Models.Ahs;
using App.Services.Utilities;

namespace App.Services.Ahs
{
    public class MediatheekService : IMediatheekService
    {
        private readonly string _bidocDomain;
        private readonly string _bidocSearchUrl;
        private readonly string _bidocGetUrl;
        private readonly int _bidocRelayPort;
        private readonly int _bidocLoginRelayPort;
        private readonly int _bidocServerPort;
        private readonly int _bidocLoginServerPort;

        public MediatheekService() 
        {
            _bidocDomain = "http://www.arteveldehogeschool.be";
            _bidocSearchUrl = _bidocDomain + "/bib/cgi-bin/bidoczoek.exe";
            _bidocGetUrl = _bidocDomain + "/bib/cgi-bin/bidocget.exe";
            _bidocServerPort = 9711;
            _bidocLoginServerPort = 9717;
            _bidocRelayPort = 6006;
            _bidocLoginRelayPort = 6008;
        }

        public IPagedList<LibraryItem> GetLibraryItemsBySimpleSearch(MediatheekSimpleSearch search)
        {
            string url = ConstructSimpleSearchUrl(search);
            if(url == null)
            {
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                string result = client.GetStringAsync(url).Result;
                if (result == null)
                    return null;


                return ConvertSimpleSearchToPagedList(result, 1, search.ItemsPerPage);
            }
        }

        public IPagedList<LibraryItem> GetLibraryItemsByAdvancedSearch(MediatheekAdvancedSearch search)
        {
            string url = ConstructAdvancedSearchUrl(search);
            if (url == null)
            {
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                string result = client.GetStringAsync(url).Result;
                if (result == null)
                    return null;


                return ConvertAdvancedSearchToPagedList(result, 1, search.ItemsPerPage);
            }
        }

        public IPagedList<LibraryItem> GetLibraryItemsByArrivalsSearch(MediatheekArrivalsSearch search)
        {
            string url = ConstructArrivalsUrl(search);
            if (url == null)
            {
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                string result = client.GetStringAsync(url).Result;
                if (result == null)
                    return null;

                return ConvertArrialsSearchToPagedList(result, 1, search.ItemsPerPage);
            }
        }

        public LibraryItem GetLibraryItemById(string libraryCode, int? libraryItemId)
        {
            string url = ConstructDetailUrl(libraryCode, libraryItemId);
            if (url == null)
            {
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                string result = client.GetStringAsync(url).Result;
                if (result == null)
                    return null;

                return ConvertDetailResultToLibraryItem(result);
            }
        }

        public ICollection<LoanerList> GetLoanerLists(int? loanerId)
        {
            string url = ConstructLoanerListsUrl(loanerId);
            if (url == null)
            {
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                string result = client.GetStringAsync(url).Result;
                if (result == null)
                    return null;

                return ConvertLoanerListSearchToList(result);
            }
        }

        private IPagedList<LibraryItem> ConvertSimpleSearchToPagedList(string result, int pageNumber, int pageSize)
        {
            //Remove callback function from json string
            int i = result.IndexOf("(");
            int j = result.LastIndexOf(")");
            string jsonString = result.Substring(i + 1, j - i - 1);

            //json string to json object
            JsonSimpleSearch jsonSimpleSearch = JsonConvert.DeserializeObject<JsonSimpleSearch>(jsonString);

            List<LibraryItem> libraryItems = new List<LibraryItem>();

            if (jsonSimpleSearch.res == null)
                return new SerializableStaticPagedList<LibraryItem>(libraryItems, pageNumber, pageSize, 0);

            
            foreach (var jsonLibraryItem in jsonSimpleSearch.res)
            {
                Nullable<short> year = null;
                string jsonYear = (string)jsonLibraryItem.r.ElementAt(4);

                if (!string.IsNullOrEmpty(jsonYear))
                {
                    jsonYear = jsonYear.Replace("-", "");
                    jsonYear = jsonYear.Replace("dep.", "");
                    year = Convert.ToInt16(jsonYear);
                }

                LibraryItem libraryItem = new LibraryItem
                {
                    Id = Convert.ToInt32(jsonLibraryItem.r.ElementAt(0)),
                    Author = (string)jsonLibraryItem.r.ElementAt(1),
                    Title = (string)jsonLibraryItem.r.ElementAt(2),
                    Type = (string)jsonLibraryItem.r.ElementAt(3),
                    Year = year
                };
                libraryItems.Add(libraryItem);
            }
            return new SerializableStaticPagedList<LibraryItem>(libraryItems, pageNumber, pageSize, jsonSimpleSearch.totaal);
        }

        private IPagedList<LibraryItem> ConvertAdvancedSearchToPagedList(string result, int pageNumber, int pageSize)
        {
            return ConvertSimpleSearchToPagedList(result, pageNumber, pageSize);
        }

        private IPagedList<LibraryItem> ConvertArrialsSearchToPagedList(string result, int pageNumber, int pageSize)
        {
            return ConvertSimpleSearchToPagedList(result, pageNumber, pageSize);
        }

        private ICollection<LoanerList> ConvertLoanerListSearchToList(string result)
        {
            //Remove callback function from json string
            int i = result.IndexOf("(");
            int j = result.LastIndexOf(")");
            string jsonString = result.Substring(i + 1, j - i - 1);

            //json string to json object
            JsonLoanerListSearch jsonLoanerListSearch = JsonConvert.DeserializeObject<JsonLoanerListSearch>(jsonString);

            return jsonLoanerListSearch.res;
        }

        private LibraryItem ConvertDetailResultToLibraryItem(string result)
        {
            //Remove callback function from json string
            int i = result.IndexOf("(");
            int j = result.LastIndexOf(")");
            string jsonString = result.Substring(i + 1, j - i - 1);

            //json string to json object
            JsonDetailSearch jsonDetailSearch = JsonConvert.DeserializeObject<JsonDetailSearch>(jsonString);
            LibraryItem libraryItem = jsonDetailSearch.res;
            libraryItem.Id = jsonDetailSearch.totaal;

            return libraryItem;
        }

        //Construct SimpleSearch Url
        private string ConstructSimpleSearchUrl(MediatheekSimpleSearch search)
        {
            if (search.SearchField == null || search.SearchField == String.Empty)
            {
                return null;
            }
            string searchFields = "zk#" + "search_callback" + "#" + search.LibraryCode + "#" + search.Offset + "#" + search.ItemsPerPage + "#s" + (int)search.SortOrder + "s#" + search.SearchField + "    ";
            return ConstructURL(searchFields);
        }

        private string ConstructAdvancedSearchUrl(MediatheekAdvancedSearch search)
        {
            if (search.SearchArrays == null || search.SearchArrays.Count == 0)
            {
                return null;
            }

            var b = search.SearchBool + "#" + search.YearReach + "#" + search.Material + "##";
            var f = 0;
            
            foreach (var searchArray in search.SearchArrays)
            {
                b += f + "-" + searchArray.ToString() + "#";
            }

            if (search.SearchArrays.Count == 0)
            {
                b += "#";
            }

            string searchFields = "zka#" + "advancedsearch_callback" + "#" + search.LibraryCode + "#" + search.Offset + "#" + search.ItemsPerPage + "#s" + search.SortOrder + "s#" + b + "    ";
            return ConstructURL(searchFields);
        }

        private string ConstructArrivalsUrl(MediatheekArrivalsSearch search)
        {
            if (search.DaysAge == null)
            {
                return null;
            }

            string searchFields = "dg#" + "arrivals_callback" + "#" + search.LibraryCode + "#" + search.Offset + "#" + search.ItemsPerPage + "#s" + search.SortOrder + "s#" + search.DaysAge + "    ";
            return ConstructURL(searchFields);
        }

        //Detail Url
        private string ConstructDetailUrl(string libraryCode, int? libraryItemId)
        {
            if (libraryItemId == null)
            {
                return null;
            }

            string searchFields = "dt#" + "detail_callback" + "#" + libraryCode + "#0#" + libraryItemId + "    ";
            return ConstructURL(searchFields);
        }

        //Loaner Lists Url
        private string ConstructLoanerListsUrl(int? loanerId) 
        {
            if (loanerId == null)
            {
                return null;
            }

            string searchFields = "act api_lis callback " + "loanerlist_callback" + " lnr " + loanerId + " val " + 0 + "    ";
            return ConstructListsUrl(searchFields);
        }

        //Construct BiDoc Url
        private string ConstructURL(string searchFields)
        {
            TimeSpan f = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            var e = EncodeFormData(searchFields);
            var b = _bidocSearchUrl + "?ts=" + Math.Round(f.TotalSeconds*1000) + "&zk=" + e;
            return b;
        }

        //Construct Lijsten Url
        private string ConstructListsUrl(string searchFields)
        {
            TimeSpan f = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            var e = EncodeFormData(searchFields);
            var b = _bidocGetUrl + "?prt=" + _bidocServerPort + "&ts=" + Math.Round(f.TotalSeconds * 1000) + "&act=groep&val=" + e;
            return b;
        }

        //Special BiDoc FormData encoding
        private string EncodeFormData(string searchFields)
        {
            string e = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_=";
            char[] eArray = e.ToCharArray();
            int d, c, b, n, m, l, k, o, h = 0;
            int p = 0;
            Array f;
            char[] searchFieldsArray;

            if (searchFields == null || searchFields == String.Empty)
            {
                return searchFields;
            }
            else
            {
                searchFieldsArray = searchFields.ToCharArray();
                f = Array.CreateInstance(typeof(string), searchFieldsArray.Length);
            }

            do
            {    
                d = Convert.ToUInt16(searchFieldsArray[h++]);
                c = Convert.ToUInt16(searchFieldsArray[h++]);
                b = Convert.ToUInt16(searchFieldsArray[h++]);
                o = d << 16 | c << 8 | b;
                n = o >> 18 & 63;
                m = o >> 12 & 63;
                l = o >> 6 & 63;
                k = o & 63;
                f.SetValue("" + eArray[n] + eArray[m] + eArray[l] + eArray[k], p++);
            } while (h < searchFieldsArray.Length-2);

            string g = "";
            for(var i=0;i<f.Length;i++)
            {
                g += (string)f.GetValue(i);
            }
            int a = searchFieldsArray.Length % 3;
            string ans = g + "$$$".Substring(0,a);
            return ans.Substring(10, ans.Length-10) + ans.Substring(0, 10);
        }
    }
}