(function () {
    'use strict';

    angular
        .module('app')
        .directive('searchBox', searchBox);

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

            // ToDo: find what this can do
            bindToController: true,
            template:
                [
                '<div class="input-group">',
                    '<input type="text" class="form-control" ng-model="vm.searchValue" placeholder="Search for..." ></input>',
                    '<span class="input-group-btn">',
                        '<button class="btn btn-default" type="button" ng-click="vm.startSearch(vm.searchValue);">Go!</button>',
                    '</span>',
                '</div>',
                '{{vm}}'
                ].join(''),

            link: link
        };

        function SearchCtrl() {
            //prototype can be used to make the function of controller accessible from link

            //SearchCtrl.prototype.search = function () {
            //    return 'Searching for "' + this.searchValue + ' on field ' + this.searchField + '"...';
            //};

            this.startSearch = startSearch;
            this.search = search;

            function startSearch() {
                console.log("start searching for " + this.searchValue);
            }

            function search() {
                return 'Searching for "' + this.searchValue + ' on field ' + this.searchField + '"...';
            };
        }

        //ToDo: use of link here isn't a good example of use of link
        // implement a beter solution
        function link($scope, $element, $attrs, $ctrl) {
            $element.bind('click', function () {
                console.log($ctrl.search());
            });
        }
    }
})();
