using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListingAPI.Models
{
    public class Listing : Document
    {
        [JsonProperty]
        public string Address { get; set; }

        [JsonProperty]
        public int Beds { get; set; }

        [JsonProperty]
        public int Baths { get; set; }

        [JsonProperty]
        public int SquareFeet { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string Status { get; set; }

        [JsonProperty]
        public Dictionary<string, string> Images { get;  set; }

        [JsonProperty]
        public List<string> ImageList
        {
            get
            {
                return Images?.Keys.ToList();
            }
        }

        [JsonProperty]
        public List<string> Keywords
        {
            get
            {
                List<string> _keywords = new List<string>();
                try
                {
                    foreach (var item in Images)
                        _keywords.AddRange(item.Value.Split(',').Select(c => c.Trim()));

                }
                catch { }

                return _keywords;

            }
        }


        [JsonProperty]
        public string OwningAgent { get; set; }

        public Listing()
        {
            Images = new Dictionary<string, string>();
        }


    }
}