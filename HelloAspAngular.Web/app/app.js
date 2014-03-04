(function () {
    'use strict';

    var app = angular.module("todoApp", [
        "ngRoute",
        "todoControllers",
        "todoServices"
    ]);

    app.config(["$routeProvider", "$httpProvider", function ($routeProvider, $httpProvider) {
        $routeProvider.
            when("/", {
                templateUrl: "/Home/Todo",
                controller: "TodoPageCtrl"
            }).
            when("/about", {
                templateUrl: "/Home/About"
            }).
            otherwise({ redirectTo: "/" });

        $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    }]);
})();