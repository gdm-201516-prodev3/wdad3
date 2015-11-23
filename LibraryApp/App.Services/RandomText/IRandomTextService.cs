using System.Collections.Generic;
using PagedList;
using App.Models;
using App.Models.RandomText;
using App.Services.Utilities;

namespace App.Services.RandomText
{
    public interface IRandomTextService
    {
        RandomTextMeSearch GetRandomText(int amountElements, int amountMinWordsPerElement, int amountMaxWordsPerElement, string format);
    }
}