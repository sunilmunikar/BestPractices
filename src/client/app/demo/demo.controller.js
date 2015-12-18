(function () {
    'use strict';

    angular
        .module('app.demo')
        .controller('DemoController', DemoController);
    //.filter('dateFileter', dateFilter);

    DemoController.$inject = ['$q', 'logger'];

    /* @ngInject */
    function DemoController($q, logger) {
        var vm = this;
        vm.title = 'Demo';
        vm.after = new Date();
        vm.duration = 100;
        vm.before = new Date();

        activate();

        function activate() {
            var promises = [];
            return $q.all(promises).then(function () {
                logger.info('Activated demo View');
            });
        }
    }

    //angular
    //    .module('app.demo')
    //    .filter('mydate', function ($filter) {
    //        return function (input) {
    //            if (input == null) { return ""; }

    //            var _date = $filter('mydate')(new Date(input), 'MMM dd yyyy');

    //            return _date.toUpperCase();
    //        };
    //    });
})();