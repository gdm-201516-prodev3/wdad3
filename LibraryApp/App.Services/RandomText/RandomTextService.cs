using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PagedList;
using App.Models;
using App.Models.RandomText;
using App.Services.Utilities;

namespace App.Services.RandomText
{
    public class RandomTextService : IRandomTextService
    {
        private readonly string _randomTextUrl;

        public RandomTextService() 
        {
            _randomTextUrl = "http://www.randomtext.me/api/lorem/{0}-{1}/{2}-{3}";
        }

        public RandomTextMeSearch GetRandomText(int amountElements, int amountMinWordsPerElement, int amountMaxWordsPerElement, string format) {
            
            string url = String.Format(_randomTextUrl, amountElements, format, amountMinWordsPerElement, amountMaxWordsPerElement);
            if(url == null)
            {
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                string result = client.GetStringAsync(url).Result;
                if (result == null)
                    return null;


                return ConvertRandomText(result);
            }
            
        }
        
        public RandomTextMeSearch ConvertRandomText(string result)
        {
            //json string to json object
            return JsonConvert.DeserializeObject<RandomTextMeSearch>(result);
        }
    }
}