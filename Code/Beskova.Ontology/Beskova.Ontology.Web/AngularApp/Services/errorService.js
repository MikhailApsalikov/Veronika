(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.service("errorService", ["$mdDialog", errorService]);

	function errorService($mdDialog) {
		return {
			open: function(errors, then) {
				$mdDialog.show({
					controller: "errorController",
					templateUrl: "/templates/error.html",
					parent: angular.element(document.body),
					clickOutsideToClose: true,
					resolve: {
						errorsData: function() {
							return errors;
						}
					}
				}).then(then, function() {});
			}
		};
	}
})();