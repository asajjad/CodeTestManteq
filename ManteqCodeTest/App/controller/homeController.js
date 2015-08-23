(function () {

    'use strict';
    angular.module('ManteqAppControllers').controller('homeController', ['$scope', '$http', function ($scope, $http) {

        $scope.title = "Manteq Code Test";
        $scope.requestList = [];
        $scope.getApprovalRequests = function () {
            $scope.requestList = [];
            $http({ method: 'GET', url: 'api/medicalprocedureapproval/getAll' }).success(function (response, status) {
                $scope.requestList = response;
                console.log('inside response ' + response + '$scope.requestList ' + $scope.requestList.length);
            });
        };

        $scope.getApprovalRequests();

        $scope.createApprovalRequest = function () {
            //save 
            $http({ method: 'POST', url: 'api/medicalprocedureapproval/createrequest' }).success(function (response, status) {
                if (response) {
                    console.log('inside response ' + response);
                }
                $scope.getApprovalRequests();
            });
        };

        //mark end of controller
    }]);
}());