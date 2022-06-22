using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guard19.Models
{
    public class Countries
    {      
            
        [JsonProperty("country")]
        public string Country { get; set; }       
    }

}
