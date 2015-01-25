(function () {
    'use strict';

    angular
        .module('app')
        .controller('User', User);

    User.$inject = ['$location'];

    function User($location) {
        this.data = {};

        /* jshint validthis:true */
        var vm = this;
        vm.title = 'validation sample ';
        vm.submit = submit;

        activate();

        function activate() { }

        function submit(valid) {
            if (!valid) return;
            console.log(valid);
        }
    }
})();
