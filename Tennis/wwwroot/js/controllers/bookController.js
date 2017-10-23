"use strict";

tennisApp.controller("BookCtrl", function ($scope, $http, $location, dataService, appConfig, appUtils) {
    $scope.book = {
        bookVisible: false
    };

    $scope.popupBook = function () {
        $scope.showBook();
    };
    $scope.booking = function (params) {
        console.log('booking')
    };

    $scope.showBook = function (params) {
        $scope.book.bookVisible = !$scope.book.bookVisible;
    };
});