# ListingsApp
A sample application that has the following components
- AngularJS Single Page Application
- ASP.net WebAPI
- Cosmos DB
- Azure Functions 
- Azure AD 
- Azure CDN

This application is a sample Real Estate Listings app, that shows how to secure an AngularJS application using Azure AD. It connects to the WebAPI also secured using Azure AD.

The WebApi makes calls to CosmosDB to pull property listings. The property images are stored in blob storage and are made available using Azure CDN

There is also an Address Verification function that is exposed via Azure Functions. Internally this uses a 3rd party provider to verify address and returns the best match.
