(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("uploadController",
			["$scope", "loginService", uploadController]);

	function uploadController($scope, loginService) {
		$scope.role = null;

		$scope.isPageVisible = function() {
			return $scope.role === loginService.roles[1];
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