using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using App.Models.Identity;

namespace App.Models.RandomUserMe
{
    public class RandomUserUser
    {
        public RandomUserUser() : base()
        {
            
        }

        [JsonProperty("user")]
		public RandomUser User { get; set; }
    }
}
