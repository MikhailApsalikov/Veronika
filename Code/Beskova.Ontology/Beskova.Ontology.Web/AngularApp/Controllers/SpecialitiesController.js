(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("specialitiesController",
			["$scope", "loginService", "baseService", "messageService", specialitiesController]);

	function specialitiesController($scope, loginService, service, messageService) {
		$scope.role = null;
		$scope.data = [];
		$scope.isLoaded = false;
		$scope.filter = {};

		$scope.reload = function() {
			$scope.isLoaded = false;
			service.getList("speciality", $scope.filter).then(function(data) {
				$scope.data = data.Data;
				$scope.isLoaded = true;
			});
		};

		$scope.details = function(id) {
			window.location.href = "/Speciality#id=" + id;
		};

		$scope.scientificSpecDetails = function(id) {
			window.location.href = "/ScientificSpeciality#id=" + id;
		};

		$scope.remove = function(id) {
			service.remove("speciality", id).then(function() {
				$scope.reload();
				messageService.show("Направление подготовки научно-педагогических кадров в аспирантуре успешно удалено");
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