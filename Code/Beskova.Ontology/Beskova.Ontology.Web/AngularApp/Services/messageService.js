(function() {
	"use strict";
	var angular = window.angular;
	angular
		.module("APP")
		.service("messageService", ["$mdToast", messageService]);

	function messageService($mdToast) {
		var duration = 5000;

		return {
			show: function(text) {
				$mdToast.show(
					$mdToast.simple()
					.textContent(text)
					.position("top right")
					.hideDelay(duration)
				);
			}
		};
	}
})();