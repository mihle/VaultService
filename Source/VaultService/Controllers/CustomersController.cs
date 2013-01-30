using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace VaultService.Controllers
{
    public class CustomersController : ApiController
    {


        // GET api/account
        public List<Customer> GetCustomers(Boolean populateComputers = false, Boolean populateUsage = false, String vault = null)
        {

            Result result = new Result();
            try
            {

                ConnectionInfo connInfo = setConnectionInfo(vault);

                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();
                SbeAccountManager.ICustomerCollection customerList;
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();

                v.Address = connInfo.Address;
                v.DefaultRaidArea = connInfo.DefaultRaidArea;
                v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                customerList = (SbeAccountManager.ICustomerCollection)com.getCustomerList(v);

                List<Customer> customers = new List<Customer>();
                
                //unfortunately we have to iterate through the list to find the match
                foreach (SbeAccountManager.ICustomer cust in customerList)
                {
                    Customer customer = new Customer();

                    // set account properties
                    customer.CustomerName = cust.Name;
                    customer.ShortName = cust.ShortName;
                    customer.CustomerEmail = cust.Email;
                    customer.Address = cust.Address;
                    customer.CustomerCity = cust.City;
                    customer.CustomerContactName =cust.ContactPerson;
                    customer.CustomerZipCode = cust.ZipCode;
                    customer.VaultName = connInfo.VaultName;
                    customer.CustomerState = cust.State;
                    customer.CustomerCountry = cust.Country;

                    customers.Add(customer);
                    

                    //int qty = 0;
                    //List<Product> products = new List<Product>();
                    //foreach (Product product in GetProductList())
                    //{

                    //    qty = 0;
                    //    qty = (int)com.GetCustomerQuota(v, customer, product.QuotaType);
                    //    if (qty < 0) qty = 0;
                    //    product.Quantity = qty;
                    //    products.Add(product);

                    //}

                    //customer.Products = products;


                    if (populateComputers == false) continue;

                    SbeAccountManager.ICollection locations;
                    locations = com.getLocationList(v, cust.Id);
                    List<Computer> computerList = new List<Computer>();

                    foreach (SbeAccountManager.ILocation location in locations)
                    {
                        // get computers
                        SbeAccountManager.ICollection computers = com.getComputerList(v, location.Id);
                        
                        customer.BillingCode = location.BillingCode;

                        foreach (SbeAccountManager.IComputer comp in computers)
                        {
                            Computer computer = new Computer();
                            computer.AgentType = comp.AgentType.ToString();
                            computer.AgentVersion = comp.AgentVersion;
                            computer.IpAddress = comp.IpAddress;
                            computer.Domain = comp.Domain;
                            computer.Name = comp.Name;
                            computer.OsType = comp.OsType;
                            computer.OsVersion = comp.OsVersion;

                            computerList.Add(computer);

                            if (populateUsage == false) continue;

                            // get tasks
                            SbeAccountManager.ICollection tasks_ = com.getTaskList(v, comp.Id);
                            List<Task> tasks = new List<Task>();
                            long totalCompressedSize = 0;
                            long totalOriginalSize = 0;
                            foreach (SbeAccountManager.ITask task_ in tasks_)
                            {
                                Task task = new Task();
                                task.Name = task_.Name;
                                task.Id = task_.Id;
                                task.IsActive = task_.IsActive;
                                task.PhysicalPoolSize = task_.PhysicalPoolSize;
                                task.UsedPoolSize = task_.UsedPoolSize;
                                tasks.Add(task);
       
                                // get safe set
                                SbeAccountManager.ICollection safeSets = com.getSafesetList(v, task_.Id);

                                foreach (SbeAccountManager.ISafeset safeSet in safeSets)
                                {
                                    totalCompressedSize += safeSet.StorageBytes;
                                    totalOriginalSize += safeSet.OriginalBytes;

                                }

                            }

                            computer.Tasks = tasks;
                            computer.TotalCompressedSize = totalCompressedSize;
                            computer.TotalOriginalSize = totalOriginalSize;

                        }

                        customer.Computers = computerList;
                    }

                }

                return customers;
            }
            catch (Exception exception)
            {

                throw exception;

            }



        }

        // GET api/account/5
        public Customer GetCustomer(string customerName, Boolean populateComputers = false, Boolean populateUsage = false, String vault = null)
        {
            try
            {

                ConnectionInfo connInfo = setConnectionInfo(vault);

                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();
                SbeAccountManager.ICustomerCollection customerList;
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();

                v.Address = connInfo.Address;
                v.DefaultRaidArea = connInfo.DefaultRaidArea;
                v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                customerList = (SbeAccountManager.ICustomerCollection)com.getCustomerList(v);

                Customer customer = null;
                Boolean found = false;
                //unfortunately we have to iterate through the list to find the match
                foreach (SbeAccountManager.ICustomer cust in customerList)
                {
                    string custName = cust.Name;

                    if (custName != customerName) continue;

                    found = true;
                    customer = new Customer();

                    // set account properties
                    customer.CustomerName = cust.Name;
                    customer.ShortName = cust.ShortName;
                    customer.CustomerEmail = cust.Email;
                    customer.Address = cust.Address;
                    customer.CustomerCity = cust.City;
                    customer.CustomerContactName =cust.ContactPerson;
                    customer.CustomerZipCode = cust.ZipCode;
                    customer.VaultName = connInfo.VaultName;
                    customer.CustomerState = cust.State;
                    customer.CustomerCountry = cust.Country;


                    

                    //int qty = 0;
                    //List<Product> products = new List<Product>();
                    //foreach (Product product in GetProductList())
                    //{

                    //    qty = 0;
                    //    qty = (int)com.GetCustomerQuota(v, customer, product.QuotaType);
                    //    if (qty < 0) qty = 0;
                    //    product.Quantity = qty;
                    //    products.Add(product);

                    //}

                    //customer.Products = products;


                    if (populateComputers == false) continue;

                    SbeAccountManager.ICollection locations;
                    locations = com.getLocationList(v, cust.Id);
                    List<Computer> computerList = new List<Computer>();

                    foreach (SbeAccountManager.ILocation location in locations)
                    {
                        // get computers
                        SbeAccountManager.ICollection computers = com.getComputerList(v, location.Id);
                        
                        customer.BillingCode = location.BillingCode;

                        foreach (SbeAccountManager.IComputer comp in computers)
                        {
                            Computer computer = new Computer();
                            computer.AgentType = comp.AgentType.ToString();
                            computer.AgentVersion = comp.AgentVersion;
                            computer.IpAddress = comp.IpAddress;
                            computer.Domain = comp.Domain;
                            computer.Name = comp.Name;
                            computer.OsType = comp.OsType;
                            computer.OsVersion = comp.OsVersion;

                            computerList.Add(computer);

                            if (populateUsage == false) continue;

                            // get tasks
                            SbeAccountManager.ICollection tasks_ = com.getTaskList(v, comp.Id);
                            List<Task> tasks = new List<Task>();
                            long totalCompressedSize = 0;
                            long totalOriginalSize = 0;
                            foreach (SbeAccountManager.ITask task_ in tasks_)
                            {
                                Task task = new Task();
                                task.Name = task_.Name;
                                task.Id = task_.Id;
                                task.IsActive = task_.IsActive;
                                task.PhysicalPoolSize = task_.PhysicalPoolSize;
                                task.UsedPoolSize = task_.UsedPoolSize;
                                tasks.Add(task);
       
                                // get safe set
                                SbeAccountManager.ICollection safeSets = com.getSafesetList(v, task_.Id);

                                foreach (SbeAccountManager.ISafeset safeSet in safeSets)
                                {
                                    totalCompressedSize += safeSet.StorageBytes;
                                    totalOriginalSize += safeSet.OriginalBytes;

                                }

                            }

                            computer.Tasks = tasks;
                            computer.TotalCompressedSize = totalCompressedSize;
                            computer.TotalOriginalSize = totalOriginalSize;

                        }

                        customer.Computers = computerList;
                    }

                    break;
                }

                return customer;
            }
            catch (Exception exception)
            {

                throw exception;

            }
        }

        // POST api/customer
        [System.Web.Http.AcceptVerbs("POST")]
        public Result CreateCustomer([FromBody]Customer customer, String vault = null)
        {
            Result result = new Result();

            try
            {

                ConnectionInfo connInfo = setConnectionInfo(vault);


                //initialize all the friggin property bags necessary to create a vault.
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();
                SbeAccountManager.CCustomer c = new SbeAccountManager.CCustomerClass();
                SbeAccountManager.CLocationClass l = new SbeAccountManager.CLocationClass();
                SbeAccountManager.CAccountClass a = new SbeAccountManager.CAccountClass();
                SbeAccountManager.CUserClass u = new SbeAccountManager.CUserClass();
                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();


                //set values from my one big property bag to all the little property bags
                //vault class
                v.Address = connInfo.Address;
                if (!String.IsNullOrEmpty(connInfo.DefaultRaidArea)) v.DefaultRaidArea = connInfo.DefaultRaidArea;
                if (!String.IsNullOrEmpty(connInfo.DefaultWorkArea)) v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                //set defaults
                if (String.IsNullOrEmpty(customer.BillingCode)) customer.BillingCode = Utilities.GenerateVaultID();
                if (String.IsNullOrEmpty(customer.Password)) customer.Password = Utilities.GeneratePassword();


                //customer class
                c.Address = customer.CustomerAddress;
                c.City = customer.CustomerCity;
                c.Name = customer.CustomerName;
                c.Email = customer.CustomerEmail;
                c.Country = customer.CustomerCountry;
                c.ZipCode = customer.CustomerZipCode;
                c.Url = customer.CustomerURL;
                c.State = customer.CustomerState;
                c.ShortName = customer.ShortName;
                c.ContactPerson = customer.CustomerContactName;

                //location class
                l.Name = customer.ShortName;
                l.BillingCode = customer.BillingCode;
                l.Email = customer.CustomerEmail;
                //account class
                a.Name = customer.ShortName;
                a.Description = customer.Description;

                //user class
                u.Name = customer.UserName;
                u.Password = customer.Password;

                //bam! create vault
                bool codeExists = false;
                com.accountAndUserExists(v, a.Name, u.Name, out codeExists);
                if (codeExists)
                {
                    throw new Exception("account already exists.");
                }
                
                com.Create(v, c, l, a, u);
                
                //set initial quota limits to 0
                // List<Product> products = new List<Product>();
                // products = GetProductList();

                // foreach (Product product in products)
                //{
                //    if (product.ProdType == Product.ProductType.Agent)
                //        com.SetCustomerQuota(v, c, product.QuotaType, 0);
                // }
                
                result.Results = customer;
            }
            catch (Exception exception)
            {
                result.ReturnCode = 1;
                result.IsError = true;
                result.Message = exception.Message;

            }

            return SetErrorResultCode(result);

        }


        // POST api/customer
        [System.Web.Http.AcceptVerbs("PUT")]
        public Result UpdateCustomer([FromBody]Customer customer, string customerName, String vault = null)
        {
            Result result = new Result();
            try
            {
                ConnectionInfo connInfo = setConnectionInfo(vault);

                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();
                SbeAccountManager.ICustomerCollection customerList;
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();

                v.Address = connInfo.Address;
                v.DefaultRaidArea = connInfo.DefaultRaidArea;
                v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                customerList = (SbeAccountManager.ICustomerCollection)com.getCustomerList(v);

                List<Customer> customers = new List<Customer>();

                //unfortunately we have to iterate through the list to find the match
                Boolean found = false;
                foreach (SbeAccountManager.ICustomer c in customerList)
                {

                    if (customerName == c.Name)
                    {
                        found = true;
                        if (!String.IsNullOrEmpty(customer.CustomerName)) c.Name = customer.CustomerName;
                        if (!String.IsNullOrEmpty(customer.CustomerAddress)) c.Address = customer.CustomerAddress;
                        if (!String.IsNullOrEmpty(customer.CustomerCity)) c.City = customer.CustomerCity;
                        if (!String.IsNullOrEmpty(customer.CustomerEmail)) c.Email = customer.CustomerEmail;
                        if (!String.IsNullOrEmpty(customer.CustomerCountry)) c.Country = customer.CustomerCountry;
                        if (!String.IsNullOrEmpty(customer.CustomerZipCode)) c.ZipCode = customer.CustomerZipCode;
                        if (!String.IsNullOrEmpty(customer.CustomerURL)) c.Url = customer.CustomerURL;
                        if (!String.IsNullOrEmpty(customer.CustomerState)) c.State = customer.CustomerState;
                        if (!String.IsNullOrEmpty(customer.CustomerContactName)) c.ContactPerson = customer.CustomerContactName;
                        c.update(v);

                        SbeAccountManager.ICollection locations;
                        locations = com.getLocationList(v, c.Id);


                        foreach (SbeAccountManager.ILocation l in locations)
                        {
                            //l.Email = customer.CustomerEmail;
                            //l.update(v, false);

                            SbeAccountManager.ICollection accounts = com.getAccountList(v, l.Id);

                            foreach (SbeAccountManager.IAccount a in accounts)
                            {

                                //a.Name = customer.ShortName;
                                //a.Description = customer.Description;
                                //a.update(v);
                            }

                        }

                        break;

                    }

                }
                if (!found)
                {
                    result.IsError = true;
                    result.ReturnCode = 2;
                    result.Message = "Customer not found";
                }
            }
            catch (Exception exception)
            {
                result.ReturnCode = 1;
                result.IsError = true;
                result.Message = exception.Message;

            }

            return SetErrorResultCode(result);

        }



        // DisableCustomer api/account/5
        public Result DisableCustomer(string customerName, String vault = null)
        {

            Result result = new Result();
            try
            {
                   ConnectionInfo connInfo = setConnectionInfo(vault);

                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();
                SbeAccountManager.ICustomerCollection customerList;
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();

                v.Address = connInfo.Address;
                v.DefaultRaidArea = connInfo.DefaultRaidArea;
                v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                customerList = (SbeAccountManager.ICustomerCollection)com.getCustomerList(v);

                List<Customer> customers = new List<Customer>();
                
                //unfortunately we have to iterate through the list to find the match
                Boolean found = false;
                foreach (SbeAccountManager.ICustomer cust in customerList)
                {

                    if (customerName == cust.Name)
                    {
                        found = true;
                        SbeAccountManager.ICollection locations;
                        locations = com.getLocationList(v, cust.Id);


                        foreach (SbeAccountManager.ILocation location in locations)
                        {
                            SbeAccountManager.ICollection accounts = com.getAccountList(v, location.Id);

                            foreach (SbeAccountManager.IAccount account in accounts)
                            {
                                com.enableObject(v, SbeAccountManager.OBJECT_TYPE_ENUM.OTE_ACCOUNT, account.Id, false);
                            }

                        }

                        break;

                    }

                }
                if (!found)
                {
                    result.IsError = true;
                    result.ReturnCode = 2;
                    result.Message = "Customer not found";
                }

            }
            catch (Exception exception)
            {
                result.ReturnCode = 1;
                result.IsError = true;
                result.Message = exception.Message;

            }

            return SetErrorResultCode(result);

             

        }


        // DisableCustomer api/account/5
        public Result EnableCustomer(string customerName, String vault = null)
        {

            Result result = new Result();
            try
            {
                ConnectionInfo connInfo = setConnectionInfo(vault);

                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();
                SbeAccountManager.ICustomerCollection customerList;
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();

                v.Address = connInfo.Address;
                v.DefaultRaidArea = connInfo.DefaultRaidArea;
                v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                customerList = (SbeAccountManager.ICustomerCollection)com.getCustomerList(v);

                List<Customer> customers = new List<Customer>();

                //unfortunately we have to iterate through the list to find the match
                Boolean found = false;
                foreach (SbeAccountManager.ICustomer cust in customerList)
                {

                    if (customerName == cust.Name)
                    {
                        found = true;
                        SbeAccountManager.ICollection locations;
                        locations = com.getLocationList(v, cust.Id);


                        foreach (SbeAccountManager.ILocation location in locations)
                        {
                            SbeAccountManager.ICollection accounts = com.getAccountList(v, location.Id);
                            
                            foreach (SbeAccountManager.IAccount account in accounts)
                            {
                                com.enableObject(v, SbeAccountManager.OBJECT_TYPE_ENUM.OTE_ACCOUNT, account.Id, true);
                            }

                        }

                        break;

                    }

                }


                if (!found)
                {
                    result.IsError = true;
                    result.ReturnCode = 2;
                    result.Message = "Customer not found";
                } 


            }
            catch (Exception exception)
            {
                result.ReturnCode = 1;
                result.IsError = true;
                result.Message = exception.Message;

            }

            return SetErrorResultCode(result);



        }


        // DisableCustomer api/account/5
        [System.Web.Http.AcceptVerbs("DELETE")]
        public Result DeleteCustomer(string customerName, String vault = null)
        {

            Result result = new Result();
            try
            {
                ConnectionInfo connInfo = setConnectionInfo(vault);

                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();
                SbeAccountManager.ICustomerCollection customerList;
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();

                v.Address = connInfo.Address;
                v.DefaultRaidArea = connInfo.DefaultRaidArea;
                v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                customerList = (SbeAccountManager.ICustomerCollection)com.getCustomerList(v);

                List<Customer> customers = new List<Customer>();

                //unfortunately we have to iterate through the list to find the match
                Boolean found = false;
                foreach (SbeAccountManager.ICustomer cust in customerList)
                {

                    string custName = cust.Name;
                    string shortName = cust.ShortName;
                    if (customerName == custName)
                    {

                        com.deleteCustomer(v, cust.Id);
                        found = true;
                        break;

                    }

                }

                if (!found){
                    result.IsError = true;
                    result.ReturnCode = 2;
                    result.Message="Customer not found";
                } 
            }
            catch (Exception exception)
            {
                result.ReturnCode = 1;
                result.IsError = true;
                result.Message = exception.Message;

            }

            return SetErrorResultCode(result);



        }



        // GET specific vault computer
        public List<Computer> GetCustomerComputers(String customerName, Boolean populateUsage = false, String vault = null)
        {
            List<Computer> computerList = new List<Computer>();

            try
            {

                ConnectionInfo connInfo = setConnectionInfo(vault);

                SbeAccountManager.CManagerClass com = new SbeAccountManager.CManagerClass();
                SbeAccountManager.ICustomerCollection customerList;
                SbeAccountManager.CVaultConnectionClass v = new SbeAccountManager.CVaultConnectionClass();

                v.Address = connInfo.Address;
                v.DefaultRaidArea = connInfo.DefaultRaidArea;
                v.DefaultWorkArea = connInfo.DefaultWorkArea;
                v.Description = connInfo.Description;
                v.Domain = connInfo.Domain;
                v.Password = connInfo.ConnectionPassword;
                v.userName = connInfo.ConnectionUser;

                com.LogFileName = connInfo.LogFileName;
                com.AuditFileName = connInfo.AuditFileName;

                customerList = (SbeAccountManager.ICustomerCollection)com.getCustomerList(v);

                Customer customer = null;
                Boolean found = false;
                //unfortunately we have to iterate through the list to find the match
                foreach (SbeAccountManager.ICustomer cust in customerList)
                {
                    string custName = cust.Name;

                    if (custName != customerName) continue;

                    found = true;
                    customer = new Customer();

                    // set account properties
                    customer.CustomerName = cust.Name;
                    customer.ShortName = cust.ShortName;
                    customer.CustomerEmail = cust.Email;
                    customer.Address = cust.Address;
                    customer.CustomerCity = cust.City;
                    customer.CustomerContactName = cust.ContactPerson;
                    customer.CustomerZipCode = cust.ZipCode;
                    customer.VaultName = connInfo.VaultName;
                    customer.CustomerState = cust.State;
                    customer.CustomerCountry = cust.Country;




                    //int qty = 0;
                    //List<Product> products = new List<Product>();
                    //foreach (Product product in GetProductList())
                    //{

                    //    qty = 0;
                    //    qty = (int)com.GetCustomerQuota(v, customer, product.QuotaType);
                    //    if (qty < 0) qty = 0;
                    //    product.Quantity = qty;
                    //    products.Add(product);

                    //}

                    //customer.Products = products;


                    SbeAccountManager.ICollection locations;
                    locations = com.getLocationList(v, cust.Id);


                    foreach (SbeAccountManager.ILocation location in locations)
                    {
                        // get computers
                        SbeAccountManager.ICollection computers = com.getComputerList(v, location.Id);

                        customer.BillingCode = location.BillingCode;

                        foreach (SbeAccountManager.IComputer comp in computers)
                        {
                            Computer computer = new Computer();
                            computer.AgentType = comp.AgentType.ToString();
                            computer.AgentVersion = comp.AgentVersion;
                            computer.IpAddress = comp.IpAddress;
                            computer.Domain = comp.Domain;
                            computer.Name = comp.Name;
                            computer.OsType = comp.OsType;
                            computer.OsVersion = comp.OsVersion;

                            computerList.Add(computer);

                            if (populateUsage == false) continue;

                            // get tasks
                            SbeAccountManager.ICollection tasks_ = com.getTaskList(v, comp.Id);
                            List<Task> tasks = new List<Task>();
                            long totalCompressedSize = 0;
                            long totalOriginalSize = 0;
                            foreach (SbeAccountManager.ITask task_ in tasks_)
                            {
                                Task task = new Task();
                                task.Name = task_.Name;
                                task.Id = task_.Id;
                                task.IsActive = task_.IsActive;
                                task.PhysicalPoolSize = task_.PhysicalPoolSize;
                                task.UsedPoolSize = task_.UsedPoolSize;
                                tasks.Add(task);

                                // get safe set
                                SbeAccountManager.ICollection safeSets = com.getSafesetList(v, task_.Id);

                                foreach (SbeAccountManager.ISafeset safeSet in safeSets)
                                {
                                    totalCompressedSize += safeSet.StorageBytes;
                                    totalOriginalSize += safeSet.OriginalBytes;

                                }

                            }

                            computer.Tasks = tasks;
                            computer.TotalCompressedSize = totalCompressedSize;
                            computer.TotalOriginalSize = totalOriginalSize;

                        }


                    }

                    break;
                }


            }
            catch (Exception exception)
            {

                throw exception;

            }
            return computerList;
        }


        // GET specific vault computer
        public Computer GetCustomerComputer(String customerName, String computerName, String vault = null)
        {
            Computer computer = new Computer();
            computer.Name = "test";
            return computer;
        }

 


        // private helper method to set connection info from config
        private ConnectionInfo setConnectionInfo(String vault)
        {

            ConnectionInfo connInfo = new ConnectionInfo();
            connInfo.LogFileName = ConfigurationManager.AppSettings["LogFileName"];
            connInfo.AuditFileName = ConfigurationManager.AppSettings["AuditFileName"];

            // if no vault is passed in, use default connection from config
            if (vault == null)
            {
                connInfo.Address = ConfigurationManager.AppSettings["Address"];
                connInfo.DefaultRaidArea = ConfigurationManager.AppSettings["DefaultRaidArea"];
                connInfo.DefaultWorkArea = ConfigurationManager.AppSettings["DefaultWorkArea"];
                connInfo.Description = ConfigurationManager.AppSettings["Description"];
                connInfo.Domain = ConfigurationManager.AppSettings["Domain"];
                connInfo.ConnectionPassword = ConfigurationManager.AppSettings["ConnectionPassword"];
                connInfo.ConnectionUser = ConfigurationManager.AppSettings["ConnectionUser"];

            }
            else
            {
                // look up correct connection from config 
                connInfo.Address = ConfigurationManager.AppSettings[vault+"-"+"Address"];
                connInfo.DefaultRaidArea = ConfigurationManager.AppSettings[vault+"-"+"DefaultRaidArea"];
                connInfo.DefaultWorkArea = ConfigurationManager.AppSettings[vault+"-"+"DefaultWorkArea"];
                connInfo.Description = ConfigurationManager.AppSettings[vault+"-"+"Description"];
                connInfo.Domain = ConfigurationManager.AppSettings[vault+"-"+"Domain"];
                connInfo.ConnectionPassword = ConfigurationManager.AppSettings[vault+"-"+"ConnectionPassword"];
                connInfo.ConnectionUser = ConfigurationManager.AppSettings[vault+"-"+"ConnectionUser"];
                connInfo.LogFileName = ConfigurationManager.AppSettings[vault+"-"+"LogFileName"];
                connInfo.AuditFileName = ConfigurationManager.AppSettings[vault+"-"+"AuditFileName"];


            }
  


            return connInfo;
        }

        private Result SetErrorResultCode(Result result)
        {


            switch (result.Message)
            {
                case "Account not found":
                    result.ReturnCode = 2;
                    break;

                case "Account already exists":
                    result.ReturnCode = 3;
                    break;

                case "User already exists":
                    result.ReturnCode = 3;
                    break;

                case "User exists under a different account":
                    result.ReturnCode = 3;
                    break;


                case "DoesNotExist":
                    result.ReturnCode = 2;
                    result.Message = "Account does not exist";
                    break;

                case "Create WebCC user failed: AlreadyExists":
                    result.Message = "User already exists";
                    result.ReturnCode = 3;
                    break;

                default:

                    break;
            }
            return result;
        }




        public Result CreateWebccCompany(ref  WebCCApi.Company webccCompany, String vault = null)
        {

            
            Result result = new Result();

            try
            {

                WebCCApi.Service webccAPI = new WebCCApi.Service();
                string CompanyID = "";

                WebCCApi.Company webccCompanyCheck = new WebCCApi.Company();
                string companyResult = webccAPI.GetCompany(webccCompany.CompanyName, out webccCompanyCheck);

                if (webccCompany.Id != null) throw new Exception("Company already exists");

                companyResult = webccAPI.CreateCompany(webccCompany, out CompanyID);

                if (companyResult != "Success")
                {
                    throw new Exception("Create Company failed: " + companyResult);

                }
                webccCompany.Id = CompanyID;

            }

            catch (Exception exception)
            {

                result.IsError = true;
                result.ReturnCode = 1;
                result.Message = exception.Message;
            }

            return result;
        }




        public Result CreateWebCCUser(ref WebCCApi.User webccUser, string clientGuid, String vault = null)
        {

            Result result = new Result();

            try
            {

                ConnectionInfo connInfo = setConnectionInfo(vault);
                WebCCApi.Service webccAPI = new WebCCApi.Service();

                webccUser.Profile.VaultName = connInfo.VaultName;
                webccUser.Profile.Address = connInfo.ExternalAddress;


                string userResult = webccAPI.CreateUser(webccUser);

                if (userResult != "Success")
                {
                    throw new Exception("Create WebCC user failed: " + userResult);

                }

            }

            catch (Exception exception)
            {
                result.IsError = true;
                result.ReturnCode = 1;
                result.Message = exception.Message;
            }

            return result;
        }

        protected List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();
            //temp code ... will replace with db call once I create the db

            products.Add(new Product("Desktop Agent", "Desktop Agent with OTM", "DESKTOP AGENT", Product.ProductType.Agent, 0));
            products.Add(new Product("Storage", "Storage", "STORAGE", Product.ProductType.Storage, 0));
            products.Add(new Product("OTM", "OTM (Open Transaction Manager)", "OTM", Product.ProductType.OTM, 0));

            return products;

        }

    }




}
