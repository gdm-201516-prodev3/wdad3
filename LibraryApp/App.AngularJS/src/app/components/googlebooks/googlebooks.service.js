/**
 * @ngdoc overview
 * @name auth.user
 * @description
 * The `ddsApp.googlebooks` module which provides:
 *
 * - {@link ...}
 * - {@link ...}
 *
 * @requires resource
 */

/**
 * @ngdoc service
 * @name ddsApp.goodreads:GoodreadsService
 * @description
 * Service with function for dealing with posts
 */

(function () {
	'use strict';

	angular
		.module('ddsApp.comp-googlebooks')
		.service('GoogleBooksService', GoogleBooksService);

	/**
	 * @ngdoc function
	 * @name ddsApp.googlebooks:GoogleBooksService
	 * @description
	 * CatalogService constructor
	 * AngularJS will instantiate a singleton by calling "new" on this function
	 *
	 * @param {Service} Goodreads The resource provided
	 * @returns {Service} {@link ...}
	 */

	GoogleBooksService.$inject = ['$q', '$http', 'GOOGLEBOOKSAPI'];

	function GoogleBooksService($q, $http, GOOGLEBOOKSAPI) {

		return {
			getBookByISBN: getBookByISBN
		};
		
		// https://www.goodreads.com/book/isbn?isbn=0441172717&key=21hXE6Ma6909sMT6FEJUg
		
		function getBookByISBN(isbn) {
			
			var url = GOOGLEBOOKSAPI.URL + isbn;
			
			var deferred = $q.defer();
			
			$http({
				method: 'GET',
				url: url
			}).then(
				function successCallback(data) {
					if(data != null && data.data != null && data.data.items != null && data.data.items.length > 0) {
						var book = data.data.items[0];
						deferred.resolve(book);
					}
					deferred.reject('No data!');
				},
				function errorCallback(error) {
					deferred.reject(error);
				}
			);

			return deferred.promise;
		}
	}

})();