/**
 * @ngdoc controller
 * @name ddsApp.controller:AppController
 * @description
 * This is the application wide controller of the ddsApp application
 */

(function () {
	'use strict';

	// register the controller as AppController
	angular
		.module('ddsApp')
		.controller('AppController', AppController);

	/**
	 * @ngdoc function
	 * @name ddsApp.provider:AppController
	 * @description
	 * Provider of the {@link ddsApp.controller:AppController AppController}
	 *
	 * @param {Auth} Auth - The authentication service used for logging out
	 * @param {$location} $mdSidenav - The sidenav service used to communicate with the sidenav components
	 */

	AppController.$inject = ['$mdSidenav'];

	function AppController($mdSidenav) {
		var vm = this;

		vm.sidenavId = 'mainMenu';

		/**
		 * @ngdoc function
		 * @name closeMainMenu
		 * @methodOf ddsApp.controller:AppController
		 * @description
		 * Close the main menu sidenav component
		 * @returns {Promise} The promise from mdSidenav
		 */
		vm.closeMainMenu = closeMainMenu;

		/**
		 * @ngdoc function
		 * @name openMainMenu
		 * @methodOf ddsApp.controller:AppController
		 * @description
		 * Open the main menu sidenav component
		 * @returns {Promise} The promise from mdSidenav
		 */
		vm.openMainMenu = openMainMenu;

		/**
		 * Close the main menu sidenav component
		 */
		function closeMainMenu() {
			return $mdSidenav(vm.sidenavId).close();
		}

		/**
		 * Open the main menu sidenav component
		 */
		function openMainMenu() {
			return $mdSidenav(vm.sidenavId).open();
		}
	}
})();
