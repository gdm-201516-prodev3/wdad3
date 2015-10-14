using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public enum ModelTypes
    {
        Object,
        Library
    }

    public enum StatusTypes
    {
        ModelValid,
        ModelInvalid,
        AddedSuccess,
        AddedFailure
    }

    public class Status
    {
        public StatusTypes Id { get; set; }
        public ModelTypes Type { get; set; }
        public string Description { get; set; }
    }

    public class LibraryStatus : Status
    {
        public LibraryStatus()
        {
            Type = ModelTypes.Library;
        }
    }
}
