(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.service("modalService", ["$mdDialog", modalService]);

	function modalService($mdDialog) {
		return {
			openCustom: function(data, templateUrl, controllerName, then, cancel) {
				$mdDialog.show({
					controller: controllerName,
					templateUrl: templateUrl,
					parent: angular.element(document.body),
					clickOutsideToClose: true,
					resolve: {
						data: function() {
							return data;
						}
					}
				}).then(then, cancel ? cancel : function() {});
			}
		};
	}
})();