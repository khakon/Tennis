"use strict";

var tennisApp = angular.module("tennisApp", [
    "ngRoute",
    "dx"
])
    .config(["$routeProvider", function ($routeProvider) {
        $routeProvider
            .when("/home", {
                templateUrl: "views/home.html",
                controller: "HomeCtrl"
            })
            //.when("/search", {
            //    templateUrl: "views/search.html",
            //    controller: "SearchCtrl"
            //})
            .when("/info", {
                templateUrl: "views/info.html",
                controller: "InfoCtrl"
            })
            .otherwise({ redirectTo: "/home" });
    }])
    .run(["$route", function ($route) {
        $route.reload();
    }]);