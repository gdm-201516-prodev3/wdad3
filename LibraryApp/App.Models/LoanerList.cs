using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LoanerList
    {
        public Int16 LoanerId { get; set; }
        public Int32 Id { get; set; }
        public LoanderListType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Int16 AmountOfLibraryItems { get; set; }
    }

    public enum LoanderListType
    {
        Private = 1,
        Public = 2,
        ReservationBasket = 3
    }
}
