/**
 * @ngdoc controller
 * @name mainMenu.controller:MainToolbarController
 * @description
 * The controller for the main menu
 *
 */

(function () {
	'use strict';

	// register the controller as MainToolbarController
	angular
		.module('ddsApp.comp-mainToolbar')
		.controller('MainToolbarController', MainToolbarController);


	/**
	 * @ngdoc function
	 * @name mainMenu.provider:MainMenuController
	 * @description
	 * Provider of the {@link mainMenu.controller:MainToolbarController MainMenuController}
	 * @param {Service} $rootScope The rootScope service to use
	 * @param {Service} mainMenu The mainMenu service to use
	 * @param {Service} $mdSidenav The mdSidenav service to use
	 * @param {Service} _ The lodash service to use
	 * @returns {Service} {@link mainMenu.controller:MainToolbarController MainMenuController}
	 */

	MainToolbarController.$inject = [];


	function MainToolbarController() {
		var vm = this;

	}

})();
