﻿(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("loginController", ["$scope", "loginService", loginController]);

	function loginController($scope, loginService) {

		$scope.login = "";
		$scope.password = "";

		$scope.submit = function() {
			loginService.login({
				Name: $scope.login,
				Password: $scope.password
			});
		};

		function activate() {
		};

		activate();
	}
})();