(function () {
    'use strict';

    angular
        .module('app')
        .factory('ReservationDataService', ReservationDataService);

    ReservationDataService.$inject = ['$http', '$timeout', '$q']

    function ReservationDataService($http, $timeout, $q) {
        var service = {
            fake: fake,
            create: create
        };
        return service;

        function fake() {
            var FAKE_TIMEOUT = 2000;
            return function (username, fakeInvalidData) {
                var defer = $q.defer();
                $timeout(function () {
                    fakeInvalidData.indexOf(username) == -1
                        ? defer.resolve()
                        : defer.reject();
                }, FAKE_TIMEOUT);
                return defer.promise;
            }
        }

        function create(reservation) {
            return $http({ method: 'POST', url: '/api/reservation/createReservation', data: reservation })
               .success(function (data, status, headers, config) {
                   //logger.info('insert(film): http post successful');
                   return data;
               });
            //.error(function (data, status, headers, config) {
            //    //logger.error(data);
            //    if (data.errorMessage) {
            //        console.error("There was a problem saving the issue: \n" + data.errorMessage + "\nPlease try again.");
            //    } else {
            //        console.log("There was a problem saving.  Please try again.");
            //    }
            //});
        }
    }
})();