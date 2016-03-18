using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSalesForce.Models
{
    public class Opportunity
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("NextStep")]
        public string NextStep { get; set; }

        [JsonProperty("LeadSource")]
        public string LeadSource { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Amount")]
        public Double Amount { get; set; }

        [JsonProperty("StageName")]
        public string StageName { get; set; }

        [JsonProperty("CloseDate")]
        public DateTime CloseDate { get; set; }

        [JsonProperty("AccountId")]
        public string AccountId { get; set; }
    }
}