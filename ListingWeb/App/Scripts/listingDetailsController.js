'use strict';
angular.module('todoApp')
    .controller('listingDetailsController', ['$scope', '$location', '$routeParams', 'listingsService', 'adalAuthenticationService', function ($scope, $location, $routeParams, listingsService, adalService) {

        $scope.error = "";
        $scope.loadingMessage = "Loading...";
        $scope.listing = null;
        $scope.keyword = "";

        $scope.listingId = $routeParams.id;



        $scope.populate = function () {
            listingsService.getListing($scope.listingId).success(function (results) {
                $scope.listing = results;
                $scope.loadingMessage = "";
            }).error(function (err) {
                $scope.error = err;
                $scope.loadingMessage = "";
            })
        };

    }]);