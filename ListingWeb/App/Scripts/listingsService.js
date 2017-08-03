'use strict';
angular.module('todoApp')
    .factory('listingsService', ['$http', function ($http) {

        var apiEndpoint = "https://madans-listingsapi.azurewebsites.net/";

        $http.defaults.useXDomain = true;
        delete $http.defaults.headers.common['X-Requested-With'];

        return {
            getListings: function () {
                return $http.get(apiEndpoint + 'api/listings');
            },
            getListing: function (id) {
                return $http.get(apiEndpoint + 'api/listings/' + id);
            },
            search: function (item) {
                return $http.post(apiEndpoint + 'search/' + item);
            }
        };
    }]);