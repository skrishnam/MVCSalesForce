using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSalesForce.Models
{
    public class AccountList
    {
        [JsonProperty("AcctList")]

        public List<Account> AcctList { get; set; }
    }
}

