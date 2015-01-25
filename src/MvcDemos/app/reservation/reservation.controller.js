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

        activate();

        function activate() { }

        function submit(valid) {
            if (!valid) return;

            return ReservationDataService.create(vm.reservation).then(function (data) {
                return data;
            },
            function (response) {
                alert(angular.toJson(response, true));
            });
        }
    }

})();
