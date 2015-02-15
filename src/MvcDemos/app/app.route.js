(function () {
    'use strict';

    angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
        $stateProvider
            .state('reservation', {
                url: '/reservation',
                templateUrl: 'app/reservation/reservation.html',
                controller: 'Reservation',
                controllerAs: 'vm'
            })
            .state('reservationServerSideOnly', {
                url: '/reservationServerSideOnly',
                templateUrl: 'app/reservation/reservationServerSideOnly.html',
                controller: 'Reservation',
                controllerAs: 'vm'
            });

        $urlRouterProvider.otherwise('/');
    })
})();