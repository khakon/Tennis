"use strict";

tennisApp.controller("HomeCtrl", function ($scope, $http, $location, dataService, appConfig, appUtils) {
    var COUNT_DAYS = 1, ENTER_CODE = 13;
    $scope.lt.page = $location.path();
    $scope.home = {
        regions: null,
        courts:null,
        offer: null,
        loadingData: true
    };
    function init() {
        $scope.home.offer = { Name: 'Test', Cover:'Test', Price: 10.00, Rating: 5 };
        dataService.getAll(appConfig.restConfig.courts).then(function (data) {
            $scope.home.courts = data;
            $scope.home.loadingData = false;
            dataService.getAll(appConfig.restConfig.regions).then(function (data) {
                $scope.home.regions = data;
                //$scope.$apply();
                $scope.$applyAsync();
            });
        });
    }
    $scope.moreInfo = function () {
        var params = {
            courtId: 14,
            startDate: appUtils.getDate(new Date()),
            endDate: appUtils.getDate(appUtils.addDays(new Date(), COUNT_DAYS))
        };
        appUtils.goToInfo($location, params);
    };

    $scope.keyPressOnClub = function (keyEvent, court) {
        if (keyEvent.which === ENTER_CODE) {
            $scope.goToInfo(court);
        }
    };

    $scope.goToInfo = function (court) {
        var params = {
            courtId: court.id,
            startDate: appUtils.getDate(new Date()),
            endDate: appUtils.getDate(appUtils.addDays(new Date(), COUNT_DAYS))
        };
        appUtils.goToInfo($location, params);
    };
    init();

});