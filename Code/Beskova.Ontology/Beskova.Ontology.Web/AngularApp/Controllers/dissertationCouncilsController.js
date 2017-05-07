(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("dissertationCouncilsController",
			["$scope", "loginService", "baseService", "messageService", dissertationCouncilsController]);

	function dissertationCouncilsController($scope, loginService, service, messageService) {
		$scope.role = null;
		$scope.data = [];
		$scope.isLoaded = false;
		$scope.filter = {};

		$scope.reload = function() {
			$scope.isLoaded = false;
			service.getList("dissertationCouncil", $scope.filter).then(function(data) {
				$scope.data = data.Data;
				$scope.isLoaded = true;
			});
		};

		$scope.details = function(id) {
			window.location.href = "/DissertationCouncil#id=" + id;
		};

		$scope.scientificSpecDetails = function(id) {
			window.location.href = "/ScientificSpeciality#id=" + id;
		};

		$scope.univDetails = function(id) {
			window.location.href = "/University#id=" + id;
		};

		$scope.remove = function(id) {
			service.remove("dissertationCouncil", id).then(function() {
				$scope.reload();
				messageService.show("Диссертационный совет успешно удален");
			});
		};

		function updateUserInfo() {
			var userInfo = loginService.getUserInfo();
			$scope.role = loginService.roles[userInfo.Role];
		}

		function activate() {
			updateUserInfo();
			$scope.reload();
		};

		activate();
	}
})();