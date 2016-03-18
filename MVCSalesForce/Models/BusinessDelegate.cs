using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
//using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;

namespace MVCSalesForce.Models
{
    public class BusinessDelegate
    {
        private string baseUrlAddress = "https://sfdcapigateway-sada.cfapps.pez.pivotal.io/";

        public List<Account> accountsList = new System.Collections.Generic.List<Account>();
        public List<Contact> contactList = new System.Collections.Generic.List<Contact>();
        public List<Opportunity> opportunityList = new System.Collections.Generic.List<Opportunity>();

        public void getAccounts()
        {
            Console.WriteLine("Inside Model getAccounts");

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrlAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // HTTP GET
            HttpResponseMessage response = client.GetAsync("authservice/oauth2").Result;
            HttpResponseMessage response1 = client.GetAsync("accountservice/accounts").Result;

            var jsonStr = response1.Content.ReadAsStringAsync();

            string jsonFullString = "{\"AcctList\":" + jsonStr.Result + "}";

            //Console.WriteLine("Inside Model getAccounts JSON FULL STRING Result:" + jsonFullString + ":");

            accountsList = JsonConvert.DeserializeObject<AccountList>(jsonFullString).AcctList;


            // string testJsonStr = "{\"AcctList\":[{\"numberOfEmployees\":null,\"Id\":\"00161000002q4UZAAY\",\"Name\":\"GenePoint\",\"Type\":\"Customer - Channel\",\"Description\":null,\"Industry\":null,\"Ownership\":null,\"Website\":null,\"Phone\":null,\"NumberOfEmployees\":null,\"Opportunities\":null,\"Contacts\":[{\"Id\":\"00361000002DjgXAAS\",\"Email\":null,\"Name\":null,\"Title\":null,\"Department\":null,\"Salutation\":null,\"Phone\":null,\"MobilePhone\":null,\"FirstName\":null,\"LastName\":\"Frank\",\"AccountId\":null,\"Account\":null}]}]}";
            // Console.WriteLine("Inside Model getAccounts TEST JSON STRING:" + testJsonStr + ":");
            // accountsList = JsonConvert.DeserializeObject<AccountList>(testJsonStr).AcctList;

            //Console.WriteLine("Inside Model getAccounts After DESERIALIZE:");
        }


        public void getAccount(string accountId)
        {
            Console.WriteLine("Inside Model getAccount Account Id:" + accountId + ":");

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrlAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            String keyStr = "accountservice/account/";

            if (string.IsNullOrEmpty(accountId) == true)
            {
                keyStr = keyStr + "00161000002q4UZAAY";
            }
            else
            {
                keyStr = keyStr + accountId;
            }

            HttpResponseMessage response1 = client.GetAsync(keyStr).Result;
            
            var jsonStr = response1.Content.ReadAsStringAsync();

            //Console.WriteLine("Inside Model getAccount jsonStr Result:" + jsonStr.Result + ":");

            Account acct = JsonConvert.DeserializeObject<Account>(jsonStr.Result);
            accountsList.Add(acct);

            // Console.WriteLine("Inside Model getAccount After DESERIALIZE:");

        }


        public void deleteAccount(string accountId)
        {
            Console.WriteLine("Inside Model Delete Account Account Id:" + accountId + ":");

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrlAddress);

            String keyStr = "accountservice/account/";

            keyStr = keyStr + accountId;

            Console.WriteLine("Inside Model DeleteAccount keyStr :" + keyStr + ":");

            HttpResponseMessage response1 = client.DeleteAsync(keyStr).Result;

            if (response1.IsSuccessStatusCode)
            {
                Console.WriteLine("Inside Model DeleteAccount After Delete SUCCESS:");
            }
            else
            {
                Console.WriteLine("Inside Model DeleteAccount After Delete FAILURE:" + response1.StatusCode + ":");
            }

            Console.WriteLine("Inside Model DeleteAccount After Delete:");
        }


        public void getContact(string contactId)
        {
            Console.WriteLine("Inside Model getContact Contact Id:" + contactId + ":");

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrlAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            String keyStr = "contactservice/contact/";

            if (string.IsNullOrEmpty(contactId) == true)
            {
                keyStr = keyStr + "00161000002q4UZAAY";
            }
            else
            {
                keyStr = keyStr + contactId;
            }

            HttpResponseMessage response1 = client.GetAsync(keyStr).Result;

            var jsonStr = response1.Content.ReadAsStringAsync();

            Console.WriteLine("Inside Model getAccount jsonStr Result:" + jsonStr.Result + ":");

            Contact contact = JsonConvert.DeserializeObject<Contact>(jsonStr.Result);
            contactList.Add(contact);

            // Console.WriteLine("Inside Model getContact After DESERIALIZE:");

        }

        public void createContact(Contact contact)
        {
            Console.WriteLine("Inside Model createContact  salutation:" + contact.Salutation + ": firstName :" + contact.FirstName + ": lastName :" + contact.LastName + ": acct Id:" + contact.AccountId + ":");

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrlAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string keyStr = "contactservice/contact/new";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(contact));

            Console.WriteLine("Inside Model createContact Http Content Result:" + content.ReadAsStringAsync().Result + ":");

            //client.PostAsync(keyStr, content);

            client.PostAsync(keyStr, content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            Console.WriteLine("Inside Model createContact AFTER POST");

            /*
               client.SendAsync(new HttpRequestMessage<Contact>(contact))
                              .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

              client.PostAsync  .SendAsync(new HttpRequestMessage<Contact>(contact)).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                                    HttpContent content = new StringC Contact();

                                    client.PostAsync(keyStr, contact)
                                                    .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                                    var client = new HttpClient();
                                    HttpContent content = new Contact();
                                    client.PostAsync<Contact>(keyStr, content, new FormUrlEncodedMediaTypeFormatter())
                                        .ContinueWith((postTask) => { postTask.Result.EnsureSuccessStatusCode(); });

                        */



            /*            // This is the postdata
                        var postData = new List<KeyValuePair<string, string>>();
                        postData.Add(new KeyValuePair<string, string>(contact.ToString(), "contact"));

                        HttpContent content = new FormUrlEncodedContent(postData);

                       //client.PostAsync(keyStr, content);
                       client.PostAsync(keyStr, content).ContinueWith(
                               (postTask) =>
                       {
                          postTask.Result.EnsureSuccessStatusCode();
                       });
            */
        }

        // MySQL
        public void loadData()
        {
            // string connString = "Database=demo;Data Source=localhost;User Id=sada;Password=password";
            string connString = "Database=test-mysql;Data Source=192.168.8.210;User Id=sPtZmvFoLSsOcM04;Password=wQTtpNeF7722CgqW";
 /*           List<Attendees> attendeeList = new System.Collections.Generic.List<Attendees>();


            Console.WriteLine("Inside loadData 1");
            Console.WriteLine("Inside loadData ConnString:" + connString + ":");

            MySqlConnection connection = new MySqlConnection(connString);
            Console.WriteLine("Inside loadData 2");
            connection.Open();
            Console.WriteLine("Inside loadData 3");

            MySqlCommand command = connection.CreateCommand();
            Console.WriteLine("Inside loadData 4");
            command.CommandText = "select * from attendees";
            Console.WriteLine("Inside loadData 5");
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Inside loadData 6");

            while (reader.Read())
            {
                reader.GetString(0);
                Attendees attnDees = new Attendees();

                attnDees.setId(Int32.Parse(reader["id"].ToString()));
                attnDees.setFirstName(reader["firstName"].ToString());
                attnDees.setLastName(reader["lastName"].ToString());

                attendeeList.Add(attnDees);
            }
            reader.Close();

            connection.Close();
*/
       }
    }

}