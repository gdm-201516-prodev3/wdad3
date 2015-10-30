(function () {
	'use strict';

	// register the route config on the application
	angular
		.module('ddsApp.catalog', ['ui.router'])
		.config(configCatalogRoute);

	// inject configCatalogRoute dependencies
	configCatalogRoute.$inject = ['$stateProvider', 'mainMenuProvider'];

	// route config function configuring the passed $stateProvider
	function configCatalogRoute($stateProvider, mainMenuProvider) {
		var mainState = {
			name: 'catalog',
			url: '/catalog',
			authenticate: false,
			templateUrl: 'app/catalog/catalog.html',
			controller: 'CatalogController',
			controllerAs: 'vm'
		};

		$stateProvider.state(mainState);

		mainMenuProvider.addMenuItem({
			name: 'Catalogus',
			state: mainState.name,
			order: 2,
			icon: 'navigation:ic_menu_24px'
		});
	}

})();