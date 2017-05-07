(function () {
	'use strict';
	var angular = window.angular;
	angular
		.module('APP')
		.controller('scientificSpecialitiesController', ['$scope', 'loginService', 'baseService', 'messageService', scientificSpecialitiesController]);

	function scientificSpecialitiesController($scope, loginService, service, messageService) {
		$scope.role = null;
		$scope.data = [];
		$scope.isLoaded = false;
		$scope.filter = {};

		$scope.reload = function () {
			$scope.isLoaded = false;
			service.getList("scientificSpeciality", $scope.filter).then(function (data) {
				$scope.data = data.Data;
				$scope.isLoaded = true;
			});
		};

		$scope.details = function (id) {
			window.location.href = "/ScientificSpeciality#id=" + id;
		};

		$scope.specDetails = function (id) {
			window.location.href = "/Speciality#id=" + id;
		};

		$scope.remove = function (id) {
			service.remove("scientificSpeciality", id).then(function () {
				$scope.reload();
				messageService.show("Научная специальность успешно удалена");
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