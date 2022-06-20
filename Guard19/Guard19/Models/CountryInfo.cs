using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guard19.Models
{
    public class CountryInfo
    {
        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [JsonProperty("lat")]
        public int Lat { get; set; }

        [JsonProperty("long")]
        public int Long { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}
