(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("dissertationCouncilController",
			["$scope", "loginService", "baseService", "messageService", dissertationCouncilController]);

	function dissertationCouncilController($scope, loginService, service) {
		$scope.data = {};
		$scope.isLoaded = false;

		$scope.reload = function() {
			$scope.isLoaded = false;
			service.getById("dissertationCouncil", getId()).then(function(data) {
				$scope.data = data;
				$scope.isLoaded = true;
			});
		};

		$scope.scientificSpecDetails = function(id) {
			window.location.href = "/ScientificSpeciality#id=" + id;
		};

		$scope.univDetails = function(id) {
			window.location.href = "/University#id=" + id;
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