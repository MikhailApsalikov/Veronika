(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("userOptionsController", ["$scope", "loginService", userOptionsController]);

	function userOptionsController($scope, loginService) {
		$scope.userName = null;
		$scope.role = null;
		$scope.isLoggedIn = function() {
			return !!$scope.userName;
		};

		$scope.logout = loginService.logout;
		$scope.isAdmin = function() {
			return $scope.role === loginService.roles[2];
		};

		$scope.navigate = function(route) {
			window.location = "/" + route;
		};

		$scope.exportOwl = function() {
			window.location = "/api/export";
		};

		function updateUserInfo() {
			var userInfo = loginService.getUserInfo();
			$scope.userName = userInfo.Name;
			$scope.role = loginService.roles[userInfo.Role];
		}

		function activate() {
			updateUserInfo();

		};

		activate();
	}
})();