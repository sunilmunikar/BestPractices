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
            .state('reservation.ClientSide', {
                url: '/ClientSide',
                templateUrl: 'app/reservation/reservationClientSide.html'
                //,
                //controller: 'Reservation',
                //controllerAs: 'vm'
            })

            .state('reservation.ServerSideOnly', {
                url: '/ServerSideOnly',
                templateUrl: 'app/reservation/reservationServerSideOnly.html'
                //,
                //controller: 'Reservation',
                //controllerAs: 'vm'
            });

        $urlRouterProvider.otherwise('/');
    })
})();
