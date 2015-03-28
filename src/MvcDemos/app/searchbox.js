(function (app) {
    'use strict';

    angular
        .module('app')
        .directive('searchBox', searchBox)

    function searchBox() {
        //<search-box search-field="music" search-term="whatever"></search-box>

        return {
            restrict: 'EA',
            scope: {
                searchField: '@',
                searchValue: '=searchTerm'
            },
            controller: SearchCtrl,
            controllerAs: 'vm',
            bindToController: true,
            template: '<div class="input-control text"><input type="text" ng-model="vm.searchValue"></input><button class="btn-search"></button></div>{{vm}}',
            link: function (scope, element, attrs, ctrl) {
                element.bind('click', function () {
                    console.log(ctrl.search());
                })
            }
        }

        function SearchCtrl() {
            SearchCtrl.prototype.search = function () {
                return 'Searching for"' + this.searchValue + ' on field ' + this.searchField + '"...';
            }
        }
    }
})();
