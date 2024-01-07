using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

#pragma warning disable CS8604 // Possible null reference argument.
namespace Web.Models
{
    public class SeoProduct
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class AdditionalProperty
        {
            [JsonProperty("@type")]
            public string type { get; set; }
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Brand
        {
            [JsonProperty("@type")]
            public string type { get; set; }
            public string name { get; set; }
        }

        public class Model
        {
            [JsonProperty("@type")]
            public string type { get; set; }

            [JsonProperty("@id")]
            public string id { get; set; }
            public string url { get; set; }
            public string name { get; set; }
            public string mpn { get; set; }
            public string sku { get; set; }
            public string gtin13 { get; set; }
            public Weight weight { get; set; }
            public string color { get; set; }
            public List<AdditionalProperty> additionalProperty { get; set; }
            public string image { get; set; }
            public Offers offers { get; set; }
        }

        public class Offers
        {
            [JsonProperty("@type")]
            public string type { get; set; }
            public string priceCurrency { get; set; }
            public double lowPrice { get; set; }
            public double highPrice { get; set; }
            public string availability { get; set; }
            public int offerCount { get; set; }
            public Seller seller { get; set; }
            public double price { get; set; }
        }

        public class Root
        {
            [JsonProperty("@context")]
            public string context { get; set; }

            [JsonProperty("@type")]
            public string type { get; set; }

            [JsonProperty("@id")]
            public string id { get; set; }
            public string name { get; set; }
            public string image { get; set; }
            public string description { get; set; }
            public string mpn { get; set; }
            public Brand brand { get; set; }
            public Offers offers { get; set; }
            public List<Model> model { get; set; }
        }

        public class Seller
        {
            [JsonProperty("@type")]
            public string type { get; set; }

            [JsonProperty("@id")]
            public string id { get; set; }
        }

        public class Weight
        {
            [JsonProperty("@type")]
            public string type { get; set; }
            public int value { get; set; }
            public string unitCode { get; set; }
        }
    }
}
#pragma warning restore CS8604 // Possible null reference argument.