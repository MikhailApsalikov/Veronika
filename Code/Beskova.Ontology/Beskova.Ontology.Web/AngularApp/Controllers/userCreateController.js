(function () {
	'use strict';
	var angular = window.angular;
	angular
      .module('APP')
      .controller('userCreateController', ['$scope', '$mdDialog', 'data', userCreateController]);

	function userCreateController($scope, $mdDialog, data) {;
		$scope.cancel = function () {
			$mdDialog.cancel();
		};

		$scope.ok = function () {
			$mdDialog.hide({
				Name: $scope.login,
				Password: $scope.password,
				Role: 0
			});
		};

		function activate() {
		}

		activate();
	}
})();