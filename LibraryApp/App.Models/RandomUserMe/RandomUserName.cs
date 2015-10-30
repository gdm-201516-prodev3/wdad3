using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using App.Models.Identity;

namespace App.Models.RandomUserMe
{
    public class RandomUserName
    {
        public RandomUserName() : base()
        {
            
        }

        [JsonProperty("title")]
        public string Title { get; set; } 
        [JsonProperty("first")]
        public string FirstName { get; set; }
        [JsonProperty("last")]
		public string SurName { get; set; }
        
    }
}
