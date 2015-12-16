(function () {
    "use strict";

    angular
        .module('app')
        .controller('ProductListCtrl',
                    ['productResource',
                        ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        productResource.getProducts().then(function (data) {
            vm.products = data;
        });
    }

    angular
    .module('app')
    .factory('productResource', ['$http', productResource]);

    function productResource($http) {
        var service =
            {
                getProducts: getProducts
            };

        return service;

        function getProducts() {
            return $http.get('/api/products').then(function myfunction(response) {
                return response.data;
            });
        }
    }
}());
