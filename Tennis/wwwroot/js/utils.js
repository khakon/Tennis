"use strict";

tennisApp.factory('appUtils', function () {

        return {
           getDate: function (date) {
                return Globalize.format(new Date(date), { skeleton: "yMd" });
            },

            addDays: function (date, days) {
                var result = new Date(date);
                result.setDate(result.getDate() + days);
                return result;
            },

            getDataForScheduler: function (scope) {
                let res = scope.reservs
                for (let index in res) {
                    let item = res[index];
                    scope.data.push({ id: item.id, startDate: new Date(item.start), endDate: new Date(item.start + item.range), courtId: item.courtId, priceId: item.priceId, trenerId: item.trenerId, total: item.total, count: item.playerCount });
                }
            },

            setOptions: function (value) {
                if (value === "xs") {
                    return {
                        largeScreen: false,
                        showTitle: false,
                        searchLabelLocation: "left",
                        views: ["agenda"],
                        currentView: "agenda",
                        offset: "0 0",
                        of: ""
                    };
                } else {
                    return {
                        largeScreen: true,
                        showTitle: true,
                        searchLabelLocation: "top",
                        views: ["day", "week", "workWeek"],
                        currentView: "week",
                        offset: "-116 195",
                        of: ".green-button"
                    };
                }
            },

            goToInfo: function ($location, params) {
                $location.path("/info").search({
                    courtId: params.courtId,
                    startDate: params.startDate,
                    endDate: params.endDate
                });
            },

            setCookie: function (name, value) {
                var cookieValue = name + "=" + encodeURIComponent(value) + ";",
                    cookiesFinishDate = new Date();
                cookiesFinishDate.setMonth(cookiesFinishDate.getMonth() + 1);
                cookieValue += "expires=" + cookiesFinishDate.toUTCString() + ";";
                cookieValue += "path=/";

                document.cookie = cookieValue;
            },

            getCookie: function (name) {
                var matches = document.cookie.match(new RegExp(
                    "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, "\\$1") + "=([^;]*)"
                ));

                return matches ? decodeURIComponent(matches[1]) : undefined;
            },

            deleteCookie: function (name) {
                document.cookie = name + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT;";
            }
        }
    }
);