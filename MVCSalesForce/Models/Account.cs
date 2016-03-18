using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSalesForce.Models
{
    public class Account
    {
        [JsonProperty("numberOfEmployees")]
        public string numberOfEmployees { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Industry")]
        public string Industry { get; set; }

        [JsonProperty("Ownership")]
        public string Ownership { get; set; }

        [JsonProperty("Website")]
        public string Website { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("NumberOfEmployees")]
        public string NumberOfEmployees { get; set; }

        [JsonProperty("Opportunities")]
        public List<Opportunity> Opportunities { get; set; }

        [JsonProperty("Contacts")]
        public List<Contact> Contacts { get; set; }

    }
}
