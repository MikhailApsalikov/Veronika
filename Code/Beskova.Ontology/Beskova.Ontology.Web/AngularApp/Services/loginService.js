(function () {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.service("loginService", ["$http", "errorService", loginService]);

	function loginService($http, errorService) {
		return {
			login: function (loginData) {
				return $http({
					url: "api/user/login",
					method: "POST",
					data: loginData
				}).then(function (responce) {
					if (!responce.data.IsValid) {
						errorService.open(responce.data.Errors);
						return;
					}
					window.localStorage.user = JSON.stringify(responce.data.ModifiedEntity);
					window.location = "/";
				});
			},
			logout: function () {
				delete window.localStorage.user;
				window.location.reload();
			},
			getUserInfo: function () {
				if (window.localStorage.user) {
					return JSON.parse(window.localStorage.user);
				}
				return {
					Role: 0
				};
			},
			roles: [
				'Пользователь',
				'Администрация министерства',
				'Администратор'
			]
		};
	}
})();