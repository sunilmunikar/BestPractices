(function () {
    'use strict';

    angular
        .module('app.demo')
        .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'demo',
                config: {
                    url: '/demo',
                    templateUrl: 'app/demo/demo.html',
                    controller: 'DemoController',
                    controllerAs: 'vm',
                    title: 'demo',
                    settings: {
                        nav: 4,
                        content: '<i class="fa fa-dashboard"></i> Demo'
                    }
                }
            }
        ];
    }
})();