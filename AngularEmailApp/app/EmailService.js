(function () {
    var email = angular.module("app");

    email.factory("emailService", ["$http",
		function ($http) {
		    var service = {};

		    service.SendEmail = function (parameters) {
		        return $http.post("http://localhost:49471/api/email/send/", parameters);
		    }

		    return service;
		}]);
})();
