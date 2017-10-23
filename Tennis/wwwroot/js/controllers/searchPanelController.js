"use strict";

tennisApp.controller("SearchPanelCtrl", function ($scope, $http,$q, $location, dataService, appConfig, appUtils) {
    var MAX_NUMBER_OF_DAYS = 60,
        MAX_NUMBER_OF_DAYS_FOR_BOOKING = 7,
        DEFAULT_COUNT_PLAYERS = 2;
    var params = $location.search();
    $scope.searchPanel = {
        courts: [{ name: 'Court#8', id: 12 }, { name: 'Court#10', id: 14 }, { name: 'Court#11', id: 15 }, { name: 'Court#14', id: 17 }, { name: 'Court#15', id: 18 }],
        covers: ['cover#1', 'cover#2', 'cover#3', 'cover#4'],
        numberOfPlayers: [1, 2, 3, 4],
        court: null,
        changeSearchVisible: false,
        players: null,
        cover: null,
        startDate: null,
        endDate: null,
        maxStartDate: appUtils.addDays(new Date(), MAX_NUMBER_OF_DAYS),
        minStartDate: new Date(),
        maxEndDate: null,
        minEndDate: new Date(),
        loadingData: true
    };

    dataService.getAll(appConfig.restConfig.courts).then(function (data) {
        $scope.searchPanel.courts = data;
            $scope.$applyAsync();
            $scope.searchPanel.loadingData = false;
        });

    $scope.$watch("searchPanel.startDate", function (newValue) {
        if (newValue) {
            $scope.searchPanel.minEndDate = newValue;
            $scope.searchPanel.maxEndDate = appUtils.addDays(newValue, MAX_NUMBER_OF_DAYS_FOR_BOOKING);
            if ((!$scope.searchPanel.endDate) || ($scope.searchPanel.endDate <= $scope.searchPanel.startDate) || ($scope.searchPanel.endDate > appUtils.addDays(newValue, MAX_NUMBER_OF_DAYS_FOR_BOOKING))) {
                var numberOfDays = parseInt(($scope.searchPanel.maxStartDate - newValue) / 1000 / 60 / 60 / 24 + 1);
                $scope.searchPanel.endDate = (numberOfDays >= MAX_NUMBER_OF_DAYS_FOR_BOOKING) ? appUtils.addDays(newValue, MAX_NUMBER_OF_DAYS_FOR_BOOKING) : appUtils.addDays(newValue, numberOfDays);
                $scope.searchPanel.maxEndDate = $scope.searchPanel.endDate;
            }
            if (!$scope.searchPanel.players) {
                $scope.searchPanel.players = DEFAULT_COUNT_PLAYERS;
            }
        }
    });

    $scope.showChangeSearch = function () {
        $scope.searchPanel.changeSearchVisible = !$scope.searchPanel.changeSearchVisible;
    };

    $scope.goToSearch = function (params) {
        var params = {
            courtId: 14,
            startDate: appUtils.getDate(new Date()),
            endDate: appUtils.getDate(appUtils.addDays(new Date(), MAX_NUMBER_OF_DAYS_FOR_BOOKING))
        };
        appUtils.goToInfo($location, params);
    };

});