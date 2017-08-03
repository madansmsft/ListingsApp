using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ListingsAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {

            DoWork();

        }

        static void DoWork()
        {

            string aadUrl = ConfigurationManager.AppSettings["ida:AADInstance"];
            string domain = ConfigurationManager.AppSettings["ida:Tenant"];

            string authority = string.Format(CultureInfo.InvariantCulture, aadUrl, domain);

            string resourceId = ConfigurationManager.AppSettings["endpointId"];
            string clientId = ConfigurationManager.AppSettings["ida:ClientID"];

            PlatformParameters p = new PlatformParameters(PromptBehavior.Auto);

            AuthenticationContext ctx = new AuthenticationContext(authority);

            var token = ctx.AcquireTokenAsync(resourceId, clientId, new Uri("https://localhost"), p).Result; // new UserCredential("madankumars@hotmail.com")).Result;


            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token.AccessToken);

            var result =  client.GetAsync("https://madans-listingsapi.azurewebsites.net/api/listings/101").Result;


            var listings = result.Content.ReadAsStringAsync();




        }
    }
}
