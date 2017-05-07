(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("userManagementController",
			["$scope", "loginService", "baseService", "modalService", "messageService", userManagementController]);

	function userManagementController($scope, loginService, service, modalService, messageService) {
		$scope.role = null;
		$scope.data = [];
		$scope.isLoaded = false;

		$scope.isPageVisible = function() {
			return $scope.role === loginService.roles[2];
		};

		$scope.reload = function() {
			$scope.isLoaded = false;
			service.getList("account").then(function(data) {
				$scope.data = data.Data;
				$scope.isLoaded = true;
			});
		};

		$scope.userRoleString = function(role) {
			return loginService.roles[role];
		};

		$scope.create = function() {
			modalService.openCustom({},
				"/templates/create-user.html",
				"userCreateController",
				function(account) {
					service.create("account", account).then(function() {
						$scope.reload();
						messageService.show("Пользователь успешно создан");
					});
				});
		};

		$scope.up = function(account) {
			account.Role = account.Role + 1;
			service.update("account", account.Id, account).then(function() {
				$scope.reload();
				messageService.show("Пользователь " + account.Name + " успешно получил права администратора");
			});
		};

		$scope.down = function(account) {
			account.Role = account.Role - 1;
			service.update("account", account.Id, account).then(function() {
				$scope.reload();
				messageService.show("Пользователь " + account.Name + " более не имеет прав администратора");
			});
		};

		$scope.remove = function(id) {
			service.remove("account", id).then(function() {
				$scope.reload();
				messageService.show("Пользователь успешно удален");
			});
		};

		function updateUserInfo() {
			var userInfo = loginService.getUserInfo();
			$scope.userName = userInfo.Name;
			$scope.role = loginService.roles[userInfo.Role];
		}

		function activate() {
			updateUserInfo();
			$scope.reload();
		};

		activate();
	}
})();