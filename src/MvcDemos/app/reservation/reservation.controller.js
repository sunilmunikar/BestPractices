(function () {
    'use strict';

    angular
        .module('app')
        .controller('Reservation', Reservation);

    Reservation.$inject = ['$location', 'ReservationDataService'];

    function Reservation($location, ReservationDataService) {
        this.reservation = {};

        /* jshint validthis:true */
        var vm = this;
        vm.title = 'validation sample ';
        vm.submit = submit;
        vm.validateServerSideOnly = true;

        activate();

        function activate() { }

        function submit(valid) {
            if (!valid && !vm.validateServerSideOnly) return;

            return ReservationDataService.create(vm.reservation).then(function (data) {
                return data;
            },
            function (response) {
                alert(JSON.stringify(response.data.ModelState));
                //alert(angular.toJson(response, true));
            });
        }

        function ValidateUserInput(reservation) {
            return $http({ method: 'POST', url: '/api/reservation/ValidateUserInput', data: reservation })
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

        function ValidateBusinessRule(reservation) {
            return $http({ method: 'POST', url: '/api/reservation/ValidateBusinessRule', data: reservation })
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