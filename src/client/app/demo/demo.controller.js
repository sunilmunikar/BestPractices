(function () {
    'use strict';

    angular
        .module('app.demo')
        .controller('DemoController', DemoController);

    DemoController.$inject = ['$q', 'logger'];

    /* @ngInject */
    function DemoController($q, logger) {
        var vm = this;
        vm.title = 'Demo';
        vm.after = new Date();
        vm.duration = 100;
        vm.before = new Date();
        vm.selectedIcon = "";
        vm.selectedIcons = ["Globe", "Heart"];
        //vm.icons = [{ "value": "Gear", "label": "<i class=\"fa fa-gear\"></i> Gear" }, { "value": "Globe", "label": "<i class=\"fa fa-globe\"></i> Globe" }, { "value": "Heart", "label": "<i class=\"fa fa-heart\"></i> Heart" }, { "value": "Camera", "label": "<i class=\"fa fa-camera\"></i> Camera" }];
        vm.icons = [];

        vm.aFloatValue = 1;

        activate();

        function activate() {
            getData();

            var promises = [];
            return $q.all(promises).then(function () {
                logger.info('Activated demo View');
            });
        }

        function getData() {
            for (var i = 0; i < 100; i++) {
                var temp = {
                    "value": i,
                    "label": "label" + i
                }
                vm.icons.push(temp);
            }
        }
    }
})();