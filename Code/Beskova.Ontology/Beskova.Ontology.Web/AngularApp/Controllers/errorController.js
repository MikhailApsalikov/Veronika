(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.controller("errorController", ["$scope", "errorsData", "$mdDialog", errorController]);

	function errorController($scope, errorsData, $mdDialog) {
		$scope.errors = errorsData;
		$scope.ok = function() {
			$mdDialog.hide();
		};

		function activate() {
		}

		activate();
	}
})();