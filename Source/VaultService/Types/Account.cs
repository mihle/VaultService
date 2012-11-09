using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaultService
{
    public class Account
    {
        #region Fields
        private List<Contact> _contacts = new List<Contact>();
        private List<Computer> _computers = new List<Computer>();
        private string accountID;
        private string parentAccountID;
        private string accountName;
        private string channelManager;
        private string channelManagerEmail;
        private string address1;
        private string address2;
        private string phone;
        private string city;
        private string state;
        private string postalCode;
        private string country;
        private string webAddress;
        private string industry;
        private string status;
        private string fax = String.Empty;
        private string _type;
        private string _productInterest;
        private string _vaultName;
        private string _divisionCode;
        private string _companyCode;
        private string _mainPhone;
        private string _mainEmail;





        #endregion

        #region Properties

        public string AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        public string DivisionCode
        {
            get { return _divisionCode; }
            set { _divisionCode = value; }
        }

        public string MainPhone
        {
            get { return _mainPhone; }
            set { _mainPhone = value; }
        }

        public string MainEmail
        {
            get { return _mainEmail; }
            set { _mainEmail = value; }
        }
        public string CompanyCode
        {
            get { return _companyCode; }
            set { _companyCode = value; }
        }

        public string VaultShortName
        {
            get { return _vaultName; }
            set { _vaultName = value; }
        }

        public string ParentAccountID
        {
            get { return parentAccountID; }
            set { parentAccountID = value; }
        }

        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }



        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }


        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }


        public string WebAddress
        {
            get { return webAddress; }
            set { webAddress = value; }
        }

        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string ProductInterest
        {
            get { return _productInterest; }
            set { _productInterest = value; }
        }


        #endregion

        public List<Contact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public List<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; }
        }

        public void AddComputer(Computer computer)
        {
            Computers.Add(computer);
        }

        public Account()
        {
            //
            // TODO: Add constructor logic here
            //
        }





    }
}