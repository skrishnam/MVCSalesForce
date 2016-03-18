using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSalesForce.Models
{
    public class Attendees
    {
        private String firstName;
        private String lastName;
        private int id;

        public int getId()
        {
            return id;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public void setId(int data)
        {
            id = data;
        }

        public void setFirstName(String data)
        {
            firstName = data;
        }

        public void setLastName(String data)
        {
            lastName = data;
        }
    }
}
