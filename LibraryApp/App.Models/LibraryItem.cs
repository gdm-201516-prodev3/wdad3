using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Utilities;

namespace App.Models
{
    public class LibraryItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [JsonProperty("Titel")]
        public string Title { get; set; }
        [JsonProperty("Auteur")]
        public string Author { get; set; }
        [JsonProperty("Taal")]
        public string Language { get; set; }
        [JsonProperty("Uitgavenvorm")]
        public string Type { get; set; }
        [JsonProperty("Uitgever")]
        public string Publisher { get; set; }
        [JsonProperty("Jaar", ItemConverterType = typeof(StringToIntJsonConverter))]
        public Nullable<int> Year { get; set; }
        [JsonProperty("Bladzijden")]
        public string Pages { get; set; }
        [JsonProperty("ISBN")]
        public string ISBN { get; set; }
        [JsonProperty("Departement")]
        public string InternalDepartment { get; set; }
        [JsonProperty("Trefwoord")]
        public string InternalTags { get; set; }
        [JsonProperty("Categorie")]
        public string InternalCategories { get; set; }
        [JsonProperty("SISO")]
        public string InternalSISO { get; set; }
    }
}