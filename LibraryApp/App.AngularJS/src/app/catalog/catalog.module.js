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
		var catalog = {
			name: 'catalog',
			url: '/catalog',
			authenticate: false,
			templateUrl: 'app/catalog/catalog.html',
			controller: 'CatalogController',
			controllerAs: 'vm'
		};
		
		var catalogSearch  = {
            name: 'catalog.search',
            parent: catalog,
            url: '/search',
            templateUrl: 'app/catalog/catalog.searh.html',
            controller:'CatalogSearchController',
            controllerAs: 'vm'
        };
		
		var catalogArrivals  = {
            name: 'catalog.arrivals',
            parent: catalog,
            url: '/arrivals',
            templateUrl: 'app/catalog/catalog.arrivals.html',
            controller:'CatalogArrivalsController',
            controllerAs: 'vm'
        };

        var catalogItemDetails = {
            name: 'catalog.details',
            parent: catalog,
            url: '/:libraryItemId',
            template: 'app/catalog/catalog.details.html',
            controller:'CatalogItemController',
            controllerAs: 'vm'
        };

		$stateProvider
			.state(catalog)
			.state(catalogSearch)
			.state(catalogArrivals)
			.state(catalogItemDetails);

		mainMenuProvider.addMenuItem({
			name: 'Catalog',
			state: catalog.name,
			order: 2,
			icon: 'action:ic_alarm_24px'
		});
	}

})();