using ListingAPI.Models;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ListingAPI.Controllers
{
    public class ListingsController : ApiController
    {

        private static readonly string endpointUrl = "https://madans-listings.documents.azure.com:443/";
        private static readonly string authorizationKey = "q1LmKNMH4rtmLKXDlS5zE7Y4znLo2FD1FJsXdIdj3K4ZvX6WCTN8Gm1vxGnJG7SrZ8nhkBSioTKg7np7BZYi9w==";
        private static readonly string databaseId = "ListingsDb";
        private static readonly string collectionId = "Listings";

        private static DocumentClient client;


        public IEnumerable<ListingSummary> Get()
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                var listings = client.CreateDocumentQuery<Listing>(
                                UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), queryOptions)
                                .Where(f => f.Status == "Active")
                        .Select(c => new ListingSummary()
                        {
                            Id = c.Id,
                            Address = c.Address,

                        }).ToList();

                return listings;
            }

        }

        [Authorize]
        public IEnumerable<Listing> Get(string id)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                var listings = client.CreateDocumentQuery<Listing>(
                                UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), queryOptions)
                                .Where(f => f.Status == "Active" && f.Id == id).ToList();

                return listings;
            }



        }


        [HttpGet]
        [Route("search/{keyword}")]
        public IEnumerable<ListingSummary> Search(string keyword)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                var listings = client.CreateDocumentQuery<Listing>(
                                UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), queryOptions)
                                .Where(f => f.Status == "Active" ).ToList();

                var filteredListings = listings.Where(
                    l => l.Address.ToUpperInvariant().Contains(keyword.ToUpperInvariant())
                        || l.Description.ToUpperInvariant().Contains(keyword.ToUpperInvariant())
                        || l.Keywords.Any(a => a.ToUpperInvariant().Contains(keyword.ToUpperInvariant())))
                        .Select (c=> new ListingSummary()
                        {
                            Id = c.Id,
                            Address = c.Address,
 
                        }).ToList();

                return filteredListings;
            }

        }



    }
}
