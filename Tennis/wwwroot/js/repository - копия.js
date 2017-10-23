"use strict";

tennisApp.factory('dataService', function ($http, $q) {
    return {
        getAll: function (url) {
            var d = $q.defer();
            $http({ method: 'GET', url: url }).
                then(function success(response) {
                    d.resolve(response.data.model);
                }, function error(response) {
                    d.reject(response.status);
                }
                );

            return d.promise;
        },
        getPar: function (url, par) {
            var d = $q.defer();
            $http({ method: 'GET', url: url, params: par }).
                then(function success(response) {
                    d.resolve(response.data.model);
                }, function error(response) {
                    d.reject(response.status);
                }
                );
            return d.promise;
        },
        post: function (url, par) {
            var d = $q.defer();
            $http({ method: 'POST', url: url, params: par }).
                then(function success(response) {
                    d.resolve(response.data.model);
                }, function error(response) {
                    d.reject(response.status);
                }
                );
            return d.promise;
        },
    }
}
);