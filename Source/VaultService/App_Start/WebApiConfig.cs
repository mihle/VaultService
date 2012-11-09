using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Mvc;
using System.Web.Routing;

namespace VaultService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // specifically wiring up the routes

            // Vault Customer routes -----------------------------------------------------------------------

            // get all customers
            config.Routes.MapHttpRoute(
                name: "Customers",
                routeTemplate: "api/customers/",
                defaults: new { controller = "Customers", populateComputers = RouteParameter.Optional, populateUsage = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // create customer
            config.Routes.MapHttpRoute(
                name: "CreateCustomer",
                routeTemplate: "api/customers/",
                defaults: new { controller = "Customers", action = "createCustomer" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );

            // get customer
            config.Routes.MapHttpRoute(
                name: "GetCustomer",
                routeTemplate: "api/customers/{customerName}",
                defaults: new { controller = "Customers", action = "getCustomer", populateComputers = RouteParameter.Optional, populateUsage = RouteParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            // update customer
            config.Routes.MapHttpRoute(
                name: "UpdateCustomer",
                routeTemplate: "api/customers/{customerName}",
                defaults: new { controller = "Customers", action = "updateCustomer" },
                constraints: new { httpMethod = new HttpMethodConstraint("PUT") }
            );

            // delete customer
            config.Routes.MapHttpRoute(
            name: "DeleteCustomer",
            routeTemplate: "api/customers/{customerName}",
            defaults: new { controller = "Customers", action = "deleteCustomer" },
            constraints: new { httpMethod = new HttpMethodConstraint("DELETE") }
            );


            // get customer computers
            config.Routes.MapHttpRoute(
                name: "VaultCustomerComputer",
                routeTemplate: "api/customers/{customerName}/computers",
                defaults: new { controller = "Customers", action = "getCustomerComputers", populateUsage = RouteParameter.Optional }
            );

            // disable customer
            config.Routes.MapHttpRoute(
                name: "VaultCustomerDisable",
                routeTemplate: "api/customers/{customerName}/disable",
                defaults: new { controller = "Customers", action = "disableCustomer" }
            );

            // enable customer
            config.Routes.MapHttpRoute(
                name: "VaultCustomerEnable",
                routeTemplate: "api/customers/{customerName}/enable",
                defaults: new { controller = "Customers", action = "enableCustomer" }
            );


            // Web CC API routes -----------------------------------------------------------------------

            // get companies
            config.Routes.MapHttpRoute(
                name: "getWebCCAPICompanies",
                routeTemplate: "api/webcc/companies",
                defaults: new { controller = "WebCCApi", action = "getCompanies" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );


            // create company
            config.Routes.MapHttpRoute(
                name: "CreateWebCCAPICompany",
                routeTemplate: "api/webcc/companies",
                defaults: new { controller = "WebCCApi", action = "createCompany" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );

            // get customer
            config.Routes.MapHttpRoute(
                name: "CreateWebCCUser",
                routeTemplate: "api/webcc/companies/{companyName}",
                defaults: new { controller = "WebCCApi", action = "createUser"},
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );


        }
    }
}
