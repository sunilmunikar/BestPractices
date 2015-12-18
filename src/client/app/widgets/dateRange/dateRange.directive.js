(function () {
    'use strict';

    angular
        .module('app')
        .directive('dateRange', dateRange);

    dateRange.$inject = [];

    function dateRange() {
        // Usage:
        //     <date-range></date-range>
        // Creates:
        //
        var directive = {
            link: link,
            restrict: 'E',
            //require: '^stTable',
            scope: {
                after: '=',
                duration: '=',
                before: '=',
                beforeIsReadonly: '@'
            },
            templateUrl: 'app/widgets/dateRange/dateRangeTemplate.html',
        };
        return directive;

        function link(scope, element, attr, ctrl) {
            var inputs = element.find('input');
            var inputBefore = angular.element(inputs[0]);
            var inputDuration = angular.element(inputs[1]);
            var inputAfter = angular.element(inputs[2]);
            var predicateName = attr.predicate;

            scope.$watch('duration', function (newVal, oldVal) {
                var updatedDate = new Date(new Date(scope.after).setMonth(scope.after.getMonth() + newVal));

                scope.before = updatedDate;
            });
            [inputBefore, inputAfter].forEach(function (input) {
                input.bind('blur', function () {
                    var query = {};

                    if (!scope.isBeforeOpen && !scope.isAfterOpen) {
                        if (scope.before) {
                            query.before = scope.before;
                        }

                        if (scope.after) {
                            query.after = scope.after;
                        }

                        scope.$apply(function () {
                            //tableCtrl.search(query, predicateName);
                        })
                    }
                });
            });

            function open(before) {
                return function ($event) {
                    $event.preventDefault();
                    $event.stopPropagation();

                    if (before) {
                        scope.isBeforeOpen = true;
                    } else {
                        scope.isAfterOpen = true;
                    }
                }
            }

            scope.openBefore = open(true);
            scope.openAfter = open();
        }
    }
})();