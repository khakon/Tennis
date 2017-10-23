tennisApp.factory('appConfig', function () {

    return {
        restConfig: {
            regions: 'api/regions/',
            courts: 'api/courts',
            court: 'api/court/',
            treners: 'api/treners/',
            prices: 'api/prices/',
            reservs: 'api/reservs/'
        }
    };
});