(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("universityController",
		["$scope", "loginService", "baseService", "messageService", universityController]);

	function universityController($scope, loginService, service) {
		$scope.data = {};
		$scope.isLoaded = false;

		$scope.reload = function() {
			$scope.isLoaded = false;
			service.getById("university", getId()).then(function(data) {
				$scope.data = data;
				$scope.isLoaded = true;
			});
		};

		$scope.scientificSpecDetails = function(id) {
			window.location.href = "/ScientificSpeciality#id=" + id;
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