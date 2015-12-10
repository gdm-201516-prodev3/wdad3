(function () {
	'use strict';

	// register the route config on the application
	angular
		.module('ddsApp.catalog', [
			'ui.router'
		])
		.config(configCatalogRoute);

	// inject configCatalogRoute dependencies
	configCatalogRoute.$inject = ['$stateProvider', 'mainMenuProvider'];

	// route config function configuring the passed $stateProvider
	function configCatalogRoute($stateProvider, mainMenuProvider) {
		var catalog = {
			name: 'catalog',
			url: '/catalog',
			abstract: true,
			authenticate: false,
			templateUrl: 'app/catalog/catalog.html',
			controller: 'CatalogController',
			controllerAs: 'vm'
		};
		
		var catalogSearch  = {
            name: 'catalog.search',
            parent: catalog,
            url: '/search',
			data: {
				'selectedTab' : 0
			},
			authenticate: false,
            templateUrl: 'app/catalog/catalog.search.html'
        };
		
		var catalogArrivals  = {
            name: 'catalog.arrivals',
            parent: catalog,
            url: '/arrivals',
			data: {
				'selectedTab' : 1
			},
			authenticate: false,
            templateUrl: 'app/catalog/catalog.arrivals.html'
        };
		
		var catalogAdvancedSearch = {
            name: 'catalog.advancedsearch',
            parent: catalog,
            url: '/advancedsearch',
			data: {
				'selectedTab' : 2
			},
			authenticate: false,
            templateUrl: 'app/catalog/catalog.advancedsearch.html'
        };

        var catalogItemDetails = {
            name: 'catalog.details',
			parent: catalog,
            url: '/{catalogItemId:[0-9]+}',
			authenticate: false,
            templateUrl: 'app/catalog/catalog.item.html',
            controller:'CatalogItemController',
            controllerAs: 'vm',
			resolve:{
				catalogItem: ['CatalogService', '$stateParams', function(CatalogService, $stateParams){
					return CatalogService.getCatalogItem($stateParams.catalogItemId, 'MAR');
				}]
			}
        };

		$stateProvider
			.state(catalog)
			.state(catalogSearch)
			.state(catalogArrivals)
			.state(catalogItemDetails);

		mainMenuProvider.addMenuItem({
			name: 'Catalog',
			state: catalogSearch.name,
			order: 2,
			icon: 'action:ic_book_24px'
		});
	}

})();