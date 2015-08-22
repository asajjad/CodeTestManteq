(function () {
    'use strict';

    /* App Module */

    var ManteqApp = angular.module('ManteqApp', [
     , 'ngRoute'
     , 'ngResource'
     , 'ngSanitize'
     , 'ManteqAppControllers'
    
    ]);

    angular.module('ManteqAppControllers', []);

    ManteqApp.config(['$routeProvider', '$httpProvider', '$locationProvider',
            function ($routeProvider, $httpProvider, $locationProvider) {

                $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';

                $routeProvider.
               when('/', {
                   templateUrl: 'app/view/home.html',
                   controller: 'homeController'
               })
                .otherwise({
                    redirectTo: '/'
                });

            }]);


}());