using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSalesForce.Models
{
    public class Contact
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }

        [JsonProperty("Salutation")]
        public string Salutation { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("MobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("AccountId")]
        public string AccountId { get; set; }

        [JsonProperty("Account")]
        public string Account { get; set; }
    }
}