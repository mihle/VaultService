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
    public class WebCCApiController : ApiController
    {



        // private helper method to set connection info from config
        private ConnectionInfo setConnectionInfo()
        {
            ConnectionInfo connInfo = new ConnectionInfo();
            connInfo.Address = ConfigurationManager.AppSettings["Address"];
            connInfo.DefaultRaidArea = ConfigurationManager.AppSettings["DefaultRaidArea"];
            connInfo.DefaultWorkArea = ConfigurationManager.AppSettings["DefaultWorkArea"];
            connInfo.Description = ConfigurationManager.AppSettings["Description"];
            connInfo.Domain = ConfigurationManager.AppSettings["Domain"];
            connInfo.ConnectionPassword = ConfigurationManager.AppSettings["ConnectionPassword"];
            connInfo.ConnectionUser = ConfigurationManager.AppSettings["ConnectionUser"];
            connInfo.LogFileName = ConfigurationManager.AppSettings["LogFileName"];
            connInfo.AuditFileName = ConfigurationManager.AppSettings["AuditFileName"];

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



        // POST Handle Create Company
        [System.Web.Http.AcceptVerbs("GET")]
        public WebCCApi.Company[] GetCompanies()
        {
            WebCCApi.Company[] companies = null;
            try
            {
                WebCCApi.Service webccAPI = new WebCCApi.Service();

                string companyResult = webccAPI.GetCompanies(out companies);

                if (companyResult != "Success")
                {
                    throw new Exception("Get Companies failed: " + companyResult);
                }

            } catch (Exception exception)
            {

                throw exception;
            }

            return companies;
        }




        // POST Handle Create Company
        [System.Web.Http.AcceptVerbs("POST")]
        public Result CreateCompany(WebCCApi.Company webccCompany)
        {

            Result result = new Result();

            try
            {
                if (String.IsNullOrWhiteSpace(webccCompany.Address1)) webccCompany.Address1 = "";
                if (String.IsNullOrWhiteSpace(webccCompany.Address2)) webccCompany.Address2 = "";
                if (String.IsNullOrWhiteSpace(webccCompany.City)) webccCompany.City = "";
                if (String.IsNullOrWhiteSpace(webccCompany.CompanyName)) webccCompany.CompanyName = "";
                if (String.IsNullOrWhiteSpace(webccCompany.ContactName)) webccCompany.ContactName = "";
                if (String.IsNullOrWhiteSpace(webccCompany.Country)) webccCompany.Country = "";
                if (String.IsNullOrWhiteSpace(webccCompany.Email)) webccCompany.Email = "";
                if (String.IsNullOrWhiteSpace(webccCompany.Fax)) webccCompany.Fax = "";
                if (String.IsNullOrWhiteSpace(webccCompany.Phone)) webccCompany.Phone = "";
                if (String.IsNullOrWhiteSpace(webccCompany.State)) webccCompany.State = "";

                WebCCApi.Service webccAPI = new WebCCApi.Service();
                string companyId = "";

                WebCCApi.Company webccCompanyCheck = null;
                string companyResult = webccAPI.GetCompany(webccCompany.CompanyName, out webccCompanyCheck);

                if (webccCompanyCheck != null) throw new Exception("Company already exists");

                companyResult = webccAPI.CreateCompany(webccCompany, out companyId);

                if (companyResult != "Success")
                {
                    throw new Exception("Create Company failed: " + companyResult);

                }
                webccCompany.Id = companyId;
                result.Results = webccCompany;
            }

            catch (Exception exception)
            {

                result.IsError = true;
                result.ReturnCode = 1;
                result.Message = exception.Message;
            }

            return result;
        }



        // POST Handle Create Company
        [System.Web.Http.AcceptVerbs("POST")]
        public Result CreateUser(string companyName, [FromBody] WebCCApi.User webccUser)
        {

            Result result = new Result();

            try
            {

                WebCCApi.Service webccAPI = new WebCCApi.Service();

                WebCCApi.Company webccCompanyCheck = null;
                string companyResult = webccAPI.GetCompany(companyName, out webccCompanyCheck);

                if (webccCompanyCheck == null) throw new Exception("Company doesn't exists");

                webccUser.CompanyId = webccCompanyCheck.Id;

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
