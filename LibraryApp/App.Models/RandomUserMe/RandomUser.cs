using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using App.Models.Identity;

namespace App.Models.RandomUserMe
{
    public class RandomUser
    {
        public RandomUser() : base()
        {
            
        }
            
        [JsonProperty("name")]
        public RandomUserName Name { get; set; }
        [JsonProperty("username")]
		public string Username { get; set; }
        [JsonProperty("email")]
		public string Email { get; set; } 
        [JsonProperty("picture")]
        public RandomUserPicture Picture { get; set; }
    }
}
