(function () {
    'use strict';

    angular
        .module('app')
        .config(function ($stateProvider, $urlRouterProvider) {
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

<<<<<<< HEAD
            .state('reservation.ServerSideOnly', {
                url: '/ServerSideOnly',
                templateUrl: 'app/reservation/reservationServerSideOnly.html'
                //,
                //controller: 'Reservation',
                //controllerAs: 'vm'
            })
            .state('search', {
                url: '/search',
                templateUrl: 'app/search.html'
                //,
                //controller: 'Reservation',
                //controllerAs: 'vm'
            });

        $urlRouterProvider.otherwise('/');
    });
=======
                .state('reservation.ServerSideOnly', {
                    url: '/ServerSideOnly',
                    templateUrl: 'app/reservation/reservationServerSideOnly.html'
                    //,
                    //controller: 'Reservation',
                    //controllerAs: 'vm'
                })
                .state('products', {
                    url: '/products',
                    templateUrl: 'app/products/productListView.html',
                    controller: 'ProductListCtrl',
                    controllerAs: 'vm'
                });

            $urlRouterProvider.otherwise('/');

        })

>>>>>>> origin/Dev
})();
