using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListingAPI.Models
{
    public class ListingSummary
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Address { get; set; }


    }
}