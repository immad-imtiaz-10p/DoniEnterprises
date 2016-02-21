using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace de_server.Models
{
    public class BusinessPartner
    {
        public int bpId;
        public generalDetails details;
        public contactDetails contact;
        public List<string> bankdetails;
        public List<contactPerson> contactPersons;

        public BusinessPartner(generalDetails gd, contactDetails cont, List<string> bank, List<contactPerson> cpDetails )
        {
            this.details = gd;
            this.contact = cont;
            this.bankdetails = bank;
            this.contactPersons = cpDetails;
        }


    }

    public class contactPerson
    {
        public string fullname;
        public string contactNum1;
        public string contactNum2;
        public string email;
        public string role;
        public Boolean isPrimary;

        public contactPerson(string fullname, string contactNum1, string contactNum2, string email, string role, Boolean isPrimary)
        {
            this.fullname = fullname;
            this.contactNum1 = contactNum1;
            this.contactNum2 = contactNum2;
            this.email = email;
            this.role = role;
            this.isPrimary = isPrimary;
        }
    }

    public class contactDetails
    {
        public List<string> emails;
        public List<string> phoneNumbers;
        public List<string> faxNumbers;
        public string address;
        public string origin;

        public contactDetails(List<string> emails, List<string> phoneNumbers, List<string> faxNumbers, string address, string origin)
        {
            this.emails = emails;
            this.phoneNumbers = phoneNumbers;
            this.faxNumbers = faxNumbers;
            this.address = address;
            this.origin = origin;
        }
    }

    public class generalDetails
    {
        public string bpName;
        public string website;
        public int ratings;
        public Boolean onDoniContract;
        public Boolean isBroker;
        public Boolean isSeller;
        public Boolean isBuyer;
        public Boolean isShipper;

        public generalDetails(string bpName, string website, int ratings, Boolean onDoniContract, Boolean isBroker,
            Boolean isBuyer, Boolean isShipper, Boolean isSeller)
        {
            this.bpName = bpName;
            this.website = website;
            this.ratings = ratings;
            this.onDoniContract = onDoniContract;
            this.isBroker = isBroker;
            this.isBuyer = isBuyer;
            this.isShipper = isShipper;
            this.isSeller = isSeller;
        }
    }

}