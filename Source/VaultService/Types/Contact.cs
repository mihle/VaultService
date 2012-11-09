using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace VaultService
{
    public class Contact
    {
        #region Fields
        protected string _id;
        protected string _type = String.Empty;
        protected string _email = String.Empty;
        protected string _phone = String.Empty;
        protected string _firstName = String.Empty;
        protected string _lastName = String.Empty;
        protected string _accountName = String.Empty;
        protected string _address1 = String.Empty;
        protected string _address2 = String.Empty;
        protected string _city = String.Empty;
        protected string _state = String.Empty;
        protected string _postalCode = String.Empty;
        protected string _country = String.Empty;
        protected bool _isPrimary;

        #endregion

        #region Public Properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }

        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public bool IsPrimary
        {
            get { return _isPrimary; }
            set { _isPrimary = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        #endregion


        public Contact()
        {
            //
            // TODO: Add constructor logic here
            //
        }

    }
}