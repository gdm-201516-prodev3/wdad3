using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using App.Models.Identity;

namespace App.Models.RandomText
{
    public class RandomTextMeSearch
    {
		/*
		{"type":"lorem","amount":5,"format":"ul","number":"5","number_max":"15","time":"12:36:30","text_out":"<ul>\r<li>Pharetra interdum sem semper aenean curabitur taciti<\/li>\r<li>Litora neque lobortis malesuada congue semper rhoncus potenti a nam cubilia potenti aptent rhoncus<\/li>\r<li>Magna tempus id primis sociosqu dictumst habitasse dictumst gravida sapien nostra curabitur rhoncus dapibus<\/li>\r<li>Elementum donec dictum est tempus dolor aliquet sem condimentum<\/li>\r<li>Fringilla lobortis ut porttitor suscipit massa<\/li>\r<\/ul>"}
		*/
        public RandomTextMeSearch() : base()
        {
            
        }
            
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("amount")]
		public int AmountElements { get; set; }
        [JsonProperty("format")]
		public string Format { get; set; } 
        [JsonProperty("number")]
        public string AmountMinWordsPerElement { get; set; }
		[JsonProperty("number_max")]
        public string AmountMaxWordsPerElement { get; set; }
        [JsonProperty("time")]
        public string CreatedAt { get; set; }
        [JsonProperty("text_out")]
        public string Results { get; set; }
    }
}
