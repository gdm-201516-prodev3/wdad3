using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Utilities
{
    [JsonObject]
    public class SerializableStaticPagedList<T> : StaticPagedList<T>
    {
        public SerializableStaticPagedList(IEnumerable<T> superset, int pageNumber, int pageSize, int totalItemCount)
            : base(superset, pageNumber, pageSize, totalItemCount)
        {
        }

        public IEnumerable<T> Items
        {
            get { return base.Subset; }
        }
    }

}
