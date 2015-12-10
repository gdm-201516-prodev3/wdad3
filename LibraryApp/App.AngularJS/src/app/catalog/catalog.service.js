/**
 * @ngdoc overview
 * @name auth.user
 * @description
 * The `ddsApp.catalog` module which provides:
 *
 * - {@link ...}
 * - {@link ...}
 *
 * @requires resource
 */

/**
 * @ngdoc service
 * @name ddsApp.catalog:Catalog
 * @description
 * Angular resource for handling communication with the api/posts route
 */

/**
 * @ngdoc service
 * @name ddsApp.catalog:CatalogService
 * @description
 * Service with function for dealing with posts
 */

(function () {
	'use strict';

	angular
		.module('ddsApp.catalog')
		.factory('CatalogSortOrders', CatalogSortOrders)
		.factory('CatalogAgeMoments', CatalogAgeMoments)
		.factory('CatalogItem', CatalogItem)
		.factory('CatalogArrival', CatalogArrival)
		.service('CatalogService', CatalogService);

	/**
	 * @ngdoc function
	 * @name ddsApp.catalog:CatalogSortOrder
	 * @description
	 * User resource constructor
	 *
	 * @param {Service} $resource The resource service to use
	 * @returns {Service} {@link ...}
	 */

	CatalogSortOrders.$inject = [];

	function CatalogSortOrders() {
		return [
			{
                'name':'Relevance',
				'nameNL':'Relevantie',
                'value':0
            },
            {
                'name':'Title',
				'nameNL':'Titel',
                'value':2
            },
            {
                'name':'Author',
				'nameNL':'Auteur',
                'value':7
            },
            {
                'name':'Setnumber',
				'nameNL':'reeksnummer',
                'value':8
            },
            {
                'name':'Year',
				'nameNL':'Jaar',
                'value':16
            },
            {
                'name':'Set',
				'nameNL':'Reeks',
                'value':18
            },
            {
                'name':'Selectionorder',
				'nameNL':'Selectievolgorde',
                'value':99
            }	
		];
	}
	
	/**
	 * @ngdoc function
	 * @name ddsApp.catalog:CatalogAgeMoments
	 * @description
	 * User resource constructor
	 *
	 * @param {Service} $resource The resource service to use
	 * @returns {Service} {@link ...}
	 */

	CatalogAgeMoments.$inject = [];

	function CatalogAgeMoments() {
		return [
			{
                'name':'1 day',
				'nameNL':'1 dag',
                'value':1
            },
            {
                'name':'5 days',
				'nameNL':'5 dagen',
                'value':5
            },
            {
                'name':'2 weeks',
				'nameNL':'2 weken',
                'value':7
            },
            {
                'name':'1 month',
				'nameNL':'1 maand',
                'value':30
            },
            {
                'name':'2 months',
				'nameNL':'2 maanden',
                'value':60
            },
            {
                'name':'3 months',
				'nameNL':'3 maanden',
                'value':90
            }	
		];
	}
	
	/**
	 * @ngdoc function
	 * @name ddsApp.catalog:CatalogItem
	 * @description
	 * User resource constructor
	 *
	 * @param {Service} $resource The resource service to use
	 * @returns {Service} {@link ...}
	 */

	CatalogItem.$inject = ['$resource', 'LIBRARYAPPAPIURL'];

	function CatalogItem($resource, LIBRARYAPPAPIURL) {
		// factory members
		var apiURL = LIBRARYAPPAPIURL + '/libraryitems/:catalogItemId';
		
		var methods = { 
			update: {
				method: 'PUT',
				params: { catalogItemId : '@id' }
			},
			get: {
				method: 'GET',
				params: { catalogItemId : '@id' }
			},
			query: { 
				method: "GET", 
				isArray: false 
			}
		};

		return $resource(apiURL, {}, methods);
	}
	
	/**
	 * @ngdoc function
	 * @name ddsApp.catalog:CatalogArrival
	 * @description
	 * User resource constructor
	 *
	 * @param {Service} $resource The resource service to use
	 * @returns {Service} {@link ...}
	 */
	
	CatalogArrival.$inject = ['$resource', 'LIBRARYAPPAPIURL'];
	
	function CatalogArrival($resource, LIBRARYAPPAPIURL) {
		// factory members
		var apiURL = LIBRARYAPPAPIURL + '/libraryitems/arrivals/';
		
		var methods = { 
			query: { 
				method: "GET", 
				isArray: false 
			}
		};

		return $resource(apiURL, {}, methods);
	}


	/**
	 * @ngdoc function
	 * @name ddsApp.catalog:CatalogService
	 * @description
	 * CatalogService constructor
	 * AngularJS will instantiate a singleton by calling "new" on this function
	 *
	 * @param {Service} Catalog The resource provided
	 * @returns {Service} {@link ...}
	 */

	CatalogService.$inject = ['$q', 'CatalogSortOrders', 'CatalogAgeMoments', 'CatalogItem', 'CatalogArrival'];

	function CatalogService($q, CatalogSortOrders, CatalogAgeMoments, CatalogItem, CatalogArrival) {

		return {
			create: create,
			update: update,
			remove: remove,
			getCatalogItem: getCatalogItem,
			getCatalogItems: getCatalogItems,
			getCatalogArrivals: getCatalogArrivals,
			getCatalogSortOrders: getCatalogSortOrders
		};

		/**
		 * @ngdoc function
		 * @name create
		 * @methodOf ddsApp.catalog:CatalogService
		 * @description
		 * Save a new catalog
		 *
		 * @param {Object} catalog The postData to save
		 * @param {Function} [callback] A callback
		 * @returns {Promise} A promise
		 */
		function create(catalog, callback) {
			var cb = callback || angular.noop;

			return CatalogItem.create(catalog,
				function (catalog) {
					return cb(catalog);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}

		/**
		 * @ngdoc function
		 * @name remove
		 * @methodOf ddsApp.catalog:CatalogService
		 * @description
		 * Remove a catalog
		 *
		 * @param {Object} catalog The postData to remove
		 * @param {Function} [callback] A callback
		 * @return {Promise} A promise
		 */
		function remove(catalog, callback) {
			var cb = callback || angular.noop;

			return CatalogItem.remove({id: catalog._id},
				function (catalog) {
					return cb(catalog);
				},
				function (err) {
					return cb(catalog);
				}).$promise;
		}

		/**
		 * @ngdoc function
		 * @name update
		 * @methodOf ddsApp.catalog:CatalogService
		 * @description
		 * Update a catalog
		 *
		 * @param {Object} catalog The postData to update
		 * @param {Function} [callback] A callback
		 * @return {Promise} A promise
		 */
		function update(catalog, callback) {
			var cb = callback || angular.noop;

			return CatalogItem.update(catalog,
				function (catalog) {
					return cb(catalog);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}
		
		/**
		 * @ngdoc function
		 * @name create
		 * @methodOf ddsApp.catalog:CatalogService
		 * @description
		 * Save a new catalog
		 *
		 * @param {Object} catalog The postData to save
		 * @param {Function} [callback] A callback
		 * @returns {Promise} A promise
		 */
		function create(catalog, callback) {
			var cb = callback || angular.noop;

			return CatalogItem.create(catalog,
				function (catalog) {
					return cb(catalog);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}
		
		function getCatalogItem(catalogItemId, libraryCode, callback) {
			var cb = callback || angular.noop;

			return CatalogItem.get({"catalogItemId": catalogItemId, "LibraryCode": libraryCode},
				function (item) {
					return cb(item);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}
		
		function getCatalogItems(searchItem, callback) {
			var cb = callback || angular.noop;


			return CatalogItem.query(searchItem,
				function (catalog) {
					return cb(catalog);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}
		
		// http://localhost:8081/api/libraryitems/arrivals?LibraryCode=MAR&ItemsPerPage=20&Offset=20&SortOrder=0&DaysAge=20
		
		function getCatalogArrivals(searchArrival, callback) {
			var cb = callback || angular.noop;

			return CatalogArrival.query(searchArrival,
				function (catalog) {
					return cb(catalog);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}
	
		function getCatalogSortOrders() {
			var deferred = $q.defer();
			
			var catalogSortOrders = CatalogSortOrders;

			if(catalogSortOrders != null && catalogSortOrders.length > 0) {
				deferred.resolve(angular.copy(catalogSortOrders));// Protect the private variable
				
			} else {
				deferred.reject('No sortorders defined!');
			}

			return deferred.promise;
		}
		
		function getCatalogAgeMoments() {
			var deferred = $q.defer();
			
			var catalogAgeMoments = CatalogAgeMoments;

			if(catalogAgeMoments != null && catalogAgeMoments.length > 0) {
				deferred.resolve(angular.copy(catalogAgeMoments));// Protect the private variable
				
			} else {
				deferred.reject('No age moments defined!');
			}

			return deferred.promise;
		}
	}

})();
