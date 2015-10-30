using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PagedList;
using App.Models;
using App.Models.RandomUserMe;
using App.Services.Utilities;

namespace App.Services.RandomUserMe
{
    public class RandomUserMeService : IRandomUserMeService
    {
        private readonly string _randomUserMeUrl;

        public RandomUserMeService() 
        {
            _randomUserMeUrl = "http://api.randomuser.me/?results={0}";
        }

        public IEnumerable<RandomUserUser> GetRandomUsers(int amount = 50)
        {
            string url = String.Format(_randomUserMeUrl, amount);
            if(url == null)
            {
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                string result = client.GetStringAsync(url).Result;
                if (result == null)
                    return null;


                return ConvertRandomUserMeToCollection(result);
            }
        }
        
        public IEnumerable<RandomUserUser> ConvertRandomUserMeToCollection(string result)
        {
            //json string to json object
            RandomUserMeSearch rumSearch = JsonConvert.DeserializeObject<RandomUserMeSearch>(result);
            return rumSearch.results;
        }
    }
}