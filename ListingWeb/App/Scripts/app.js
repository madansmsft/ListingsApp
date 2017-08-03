'use strict';
angular.module('todoApp', ['ngRoute','AdalAngular'])
.config(['$routeProvider', '$httpProvider', 'adalAuthenticationServiceProvider', function ($routeProvider, $httpProvider, adalProvider) {

    $routeProvider
    .when("/Home", {
        controller: "listingsController",
        templateUrl: "/App/Views/Listings.html",
        requireADLogin: true,
        })
    .when("/listing/:id", {
        controller: "listingDetailsController",
        templateUrl: "/App/Views/ListingDetails.html",
        requireADLogin: true,
        })
    .when("/UserData", {
        controller: "userDataCtrl",
        templateUrl: "/App/Views/UserData.html",
        })
    .otherwise({ redirectTo: "/Home" });

    var endpoints = {

        // Map the location of a request to an API to a the identifier of the associated resource
        "https://madans-listingsapi.azurewebsites.net/":
            "https://madankumarshotmail.onmicrosoft.com/listingsapi",
    };

    adalProvider.init(
        {
            instance: 'https://login.microsoftonline.com/',
            tenant: 'madankumarshotmail.onmicrosoft.com',
            clientId: 'c68108d5-bd50-491e-aa26-e352fe546de3',
            extraQueryParameter: 'nux=1',
            endpoints: endpoints,
            //cacheLocation: 'localStorage', // enable this for IE, as sessionStorage does not work for localhost.  
            // Also, token acquisition for the To Go API will fail in IE when running on localhost, due to IE security restrictions.
        },
        $httpProvider
        );
   
}]);
