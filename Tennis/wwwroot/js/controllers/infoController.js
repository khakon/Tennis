"use strict";

tennisApp.controller("InfoCtrl", function ($scope, $http, $q, $location, dataService, appConfig, appUtils) {
    var params = $location.search();
    $scope.lt.page = $location.path();
    $scope.reservs = [];
    $scope.prices = [];
    $scope.treners = [];
    $scope.data = [];
    $scope.info = {
        loadingData: true,
        currentDate: new Date(params.startDate),
        date:''
    };
    $scope.options = {
        dataSource: $scope.data,
        views: ["day", "workWeek", "month"],
        currentView: "workWeek",
        startDayHour: 12,
        endDayHour: 24,
        height: 527,
        appointmentTemplate: "appointment-template",
        appointmentTooltipTemplate: "tooltip-template"
    }

    $scope.position = { at: 'bottom', offset: '-116 175', of: '.green-button' };

    $scope.getPriceById = function(id) {
        return DevExpress.data.query($scope.prices).filter(["id", "=", id]).toArray()[0];
    };
    $scope.getTrenerById = function(id) {
        return DevExpress.data.query($scope.treners).filter(["id", "=", id]).toArray()[0];
    };
    $scope.getCustomers = function (id) {
        let res = DevExpress.data.query($scope.customers).filter(["reservationId", "=", id]).select("name").toArray();
        if (res.length === 0) return 'No subscribe';
        else {
            let dt = [];
            for (let index in res) {
                let item = res[index];
                dt.push(item.name);
            }
            return dt.join();
        };
    };
    $scope.getDateForView = function (res) {
        let startDate, endDate;
        $q.all([DevExpress.data.query(res)
            .select(function (item) {
                return item.start;
            })
            .min(),
        DevExpress.data.query(res)
            .select(function (item) {
                return item.start;
            })
            .max()]
        ).then(function (data) {
            startDate = new Date(data[0]);
            endDate = new Date(data[1]);
            $scope.info.date = Globalize.format(startDate, { raw: "E dd" }) + " - " + Globalize.format(endDate, { raw: "E dd, MMMM yyyy" });
        });

    },
    $q.all([dataService.getAll(appConfig.restConfig.reservs + new String(params.courtId)), dataService.getAll(appConfig.restConfig.reservs + 'GetCustomers/' + new String(params.courtId))
        , dataService.getAll(appConfig.restConfig.treners), dataService.getAll(appConfig.restConfig.prices), dataService.getPar(appConfig.restConfig.court, { key: params.courtId })])
        .then(function (data) {
            $scope.reservs = data[0];
            $scope.customers = data[1];
            $scope.treners = data[2];
            $scope.prices = data[3];
            $scope.court = data[4];
            /////////replace///////
            $scope.court.cover = 'Test cover';
            /////////replace///////
            appUtils.getDataForScheduler($scope);
            $scope.getDateForView($scope.reservs);
            $scope.info.loadingData = false;
            $(".responsive-info").dxResponsiveBox("instance").repaint();
            $(".scheduler").dxScheduler("instance").repaint();
            $scope.$applyAsync();
        });
});