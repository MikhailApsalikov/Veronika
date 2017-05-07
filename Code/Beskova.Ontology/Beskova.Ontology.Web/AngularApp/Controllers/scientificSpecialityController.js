(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("scientificSpecialityController",
			["$scope", "loginService", "baseService", "messageService", scientificSpecialityController]);

	function scientificSpecialityController($scope, loginService, service) {
		$scope.data = {};
		$scope.isLoaded = false;

		$scope.reload = function() {
			$scope.isLoaded = false;
			service.getById("scientificSpeciality", getId()).then(function(data) {
				$scope.data = data;
				$scope.isLoaded = true;
			});
		};

		$scope.specDetails = function(id) {
			window.location.href = "/Speciality#id=" + id;
		};

		function getId() {
			try {
				return /\#id=(.*)/.exec(window.location.hash)[1];
			} catch (e) {
				window.location.href = window.baseUri;
			}
		}

		function activate() {
			$scope.reload();
		};

		activate();
	}
})();