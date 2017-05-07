(function () {
	'use strict';
	var angular = window.angular;
	angular
		.module('APP')
		.controller('scientificSpecialtiesController', ['$scope', 'loginService', 'baseService', 'messageService', scientificSpecialtiesController]);

	function scientificSpecialtiesController($scope, loginService, service, messageService) {
		$scope.role = null;
		$scope.data = [];
		$scope.isLoaded = false;

		$scope.reload = function () {
			$scope.isLoaded = false;
			service.getList("scientificSpeciality").then(function (data) {
				$scope.data = data.Data;
				$scope.isLoaded = true;
			});
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