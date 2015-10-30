using System.Collections.Generic;
using PagedList;
using App.Models;
using App.Models.RandomUserMe;
using App.Services.Utilities;

namespace App.Services.RandomUserMe
{
    public interface IRandomUserMeService
    {
        IEnumerable<RandomUserUser> GetRandomUsers(int amount);
    }
}