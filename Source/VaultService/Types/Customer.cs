using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for Order
/// </summary>
/// 
namespace VaultService
{
    public class Customer
    {
        #region Fields
        protected string _vaultName = String.Empty;
        protected string _shortName = String.Empty;
        protected string _address = String.Empty;
        protected string _userID = String.Empty;
        protected string _password = String.Empty;
        protected string _domain = String.Empty;
        protected string _description = String.Empty;
        protected string _defaultRaidArea = String.Empty;
        protected string _defaultWorkArea = String.Empty;
        protected string _billingCode = String.Empty;
        protected string _connectionUser = String.Empty;
        protected string _connectionPassword = String.Empty;


        protected string _customerName = String.Empty;
        protected string _customerAddress = String.Empty;
        protected string _customerCity = String.Empty;
        protected string _customerZipCode = String.Empty;
        protected string _customerState = String.Empty;
        protected string _customerCountry = String.Empty;
        protected string _customerURL = String.Empty;
        protected string _customerNotes = String.Empty;
        protected string _customerEmail = String.Empty;
        protected string _customerContactName = String.Empty;
        private List<Computer> _computers = new List<Computer>();
        private List<Product> _products = new List<Product>();



        #endregion

        #region Public Properties

        protected string ConnectionUser
        {
            get { return _connectionUser; }
            set { _connectionUser = value; }

        }

        protected string ConnectionPassword
        {
            get { return _connectionPassword; }
            set { _connectionPassword = value; }

        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; }
        }


        public string CustomerCity
        {
            get { return _customerCity; }
            set { _customerCity = value; }
        }

        public string CustomerZipCode
        {
            get { return _customerZipCode; }
            set { _customerZipCode = value; }
        }

        public string CustomerState
        {
            get { return _customerState; }
            set { _customerState = value; }
        }


        public string CustomerCountry
        {
            get { return _customerCountry; }
            set { _customerCountry = value; }
        }

        public string CustomerURL
        {
            get { return _customerURL; }
            set { _customerURL = value; }
        }

        public string CustomerNotes
        {
            get { return _customerNotes; }
            set { _customerNotes = value; }
        }

        public string CustomerEmail
        {
            get { return _customerEmail; }
            set { _customerEmail = value; }
        }

        public string CustomerContactName
        {
            get { return _customerContactName; }
            set { _customerContactName = value; }
        }


        public string VaultName
        {
            get { return _vaultName; }
            set { _vaultName = value; }
        }




        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }

        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string UserName
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string DefaultRaidArea
        {
            get { return _defaultRaidArea; }
            set { _defaultRaidArea = value; }
        }

        public string DefaultWorkArea
        {
            get { return _defaultWorkArea; }
            set { _defaultWorkArea = value; }
        }

        public string BillingCode
        {
            get { return _billingCode; }
            set { _billingCode = value; }
        }

      
        public List<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; }
        }

        protected List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        #endregion



        public Customer()
        {
            //
            // TODO: Add constructor logic here
            //
        }

    }


}