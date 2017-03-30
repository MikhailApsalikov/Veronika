(function () {
	'use strict';
	var angular = window.angular;
	angular
      .module('APP')
      .controller('errorController', ['$scope', 'errorsData', errorController]);

	function errorController($scope, errorsData) {
		$scope.errors = errorsData;
		$scope.ok = function () {
			//$uibModalInstance.close();
		};

		function activate() {
		}

		activate();
	}
})();