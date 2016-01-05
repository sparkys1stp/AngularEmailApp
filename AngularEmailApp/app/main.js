(function () {
    'use strict';
    
    angular
        .module('app')
        .controller('Main', ["$scope", "emailService",
        function ($scope, emailService) {
         

            $scope.sendEmail = function () {
                console.log($scope.vm.Message);
               emailService.SendEmail($scope.vm);
            };
        }



        ]);
})();