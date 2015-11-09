using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using App.Models.Identity;

namespace App.Models.RandomUserMe
{
    public class RandomUserPicture
    {
        public RandomUserPicture() : base()
        {
            
        }

        [JsonProperty("large")]
        public string Large { get; set; } 
        [JsonProperty("medium")]
        public string Medium { get; set; }
        [JsonProperty("thumbnail")]
		public string Small { get; set; }
        
    }
}
