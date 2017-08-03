'use strict';
angular.module('todoApp')
    .controller('listingsController', ['$scope', '$location', 'listingsService', 'adalAuthenticationService', function ($scope, $location, listingsService, adalService) {

        $scope.error = "";
        $scope.loadingMessage = "Loading...";
        $scope.listings = null;
        $scope.keyword = "";



        $scope.populate = function () {
            listingsService.getListings().success(function (results) {
                $scope.listings = results;
                $scope.loadingMessage = "";
            }).error(function (err) {
                $scope.error = err;
                $scope.loadingMessage = "";
            })
        };

        $scope.search = function () {
            todoListSvc.search($scope.keyword).success(function (results) {
                $scope.loadingMessage = "";
                $scope.listings = results;
            }).error(function (err) {
                $scope.error = err;
                $scope.loadingMessage = "";
            })
        };
    }]);