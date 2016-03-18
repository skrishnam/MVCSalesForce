using MVCSalesForce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSalesForce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Load All Accounts
        public ActionResult Accounts()
        {
            ViewBag.Message = "Your Accounts page.";

            BusinessDelegate obj = new BusinessDelegate();
            obj.getAccounts();

            ViewData["AccountList"] = obj.accountsList;

            return View();
        }

        // Single Account
        public ActionResult SingleAccount()
        {
            ViewBag.Message = "Your Accounts page.";

            string acctId = Request.QueryString["acctId"];
            string editFlag = Request.Params["editFlag"];

            Console.WriteLine("Inside Controller SingleAccount  Acct Id:" + acctId + ": Edit Flag :" + editFlag + ":");

            BusinessDelegate obj = new BusinessDelegate();

            if (editFlag.Equals("0"))  // READ
            {
                obj.getAccount(acctId);

                ViewData["AccountList"] = obj.accountsList;
            }
            else if (editFlag.Equals("1")) // UPDATE
            {
                List<Account> accountsList = new System.Collections.Generic.List<Account>();
                ViewData["AccountList"] = accountsList;
            }
            else // DELETE
            {
                obj.deleteAccount(acctId);

                List<Account> accountsList = new System.Collections.Generic.List<Account>();
                ViewData["AccountList"] = accountsList;
            }

            return View();
        }

        public ActionResult AcctContact()
        {
            ViewBag.Message = "Your Accounts page.";

            string contactId = Request.QueryString["contactId"];

            BusinessDelegate obj = new BusinessDelegate();
            obj.getContact(contactId);

            ViewData["ContactList"] = obj.contactList;

            return View();
        }

        public ActionResult AcctNewContact()
        {
            ViewBag.Message = "Your Accounts page.";

            string contactId = Request.QueryString["contactId"];

            BusinessDelegate obj = new BusinessDelegate();

            string salutation = Request.QueryString["salutation"];
            string firstName = Request.Params["firstName"];
            string lastName = Request.Params["lastName"];
            string acctId = Request.QueryString["acctId"];

            Console.WriteLine("Inside Controller AcctNewContact  salutation:" + salutation + ": firstName :" + firstName + ": lastName :" + lastName + ": acct Id:" + acctId + ":");

            if (string.IsNullOrEmpty(firstName) != true)
            {
                Contact contact = new Contact();

                contact.Salutation = salutation;
                contact.FirstName = firstName;
                contact.LastName = lastName;
                contact.AccountId = acctId;

                obj.createContact(contact);
            }

            ViewData["AccountId"] = acctId;

            return View();
        }

        public ActionResult Attendees()
        {
            ViewBag.Message = "Your Attendees page.";
            /*
                        BusinessDelegate obj = new BusinessDelegate();
                        obj.loadData();

                        ViewData["noOfAttendees"] = obj.attendeeList.Count;
                        ViewData["AttendeeList"] = obj.attendeeList;
            */
            return View();
        }

    }
}