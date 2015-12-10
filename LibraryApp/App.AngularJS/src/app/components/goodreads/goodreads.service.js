/**
 * @ngdoc overview
 * @name auth.user
 * @description
 * The `ddsApp.goodreads` module which provides:
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
		.module('ddsApp.comp-goodreads')
		.service('GoodreadsService', GoodreadsService);

	/**
	 * @ngdoc function
	 * @name ddsApp.goodreads:GoodreadsService
	 * @description
	 * CatalogService constructor
	 * AngularJS will instantiate a singleton by calling "new" on this function
	 *
	 * @param {Service} Goodreads The resource provided
	 * @returns {Service} {@link ...}
	 */

	GoodreadsService.$inject = ['$q', '$http', 'GOODREADSAPI'];

	function GoodreadsService($q, $http, GOODREADSAPI) {

		return {
			getBookReviewByISBN: getBookReviewByISBN
		};
		
		// https://www.goodreads.com/book/isbn?isbn=0441172717&key=21hXE6Ma6909sMT6FEJUg
		
		function getBookReviewByISBN(isbn) {
			
			var url = GOODREADSAPI.URL + 'isbn?' + 'isbn=' + isbn + '&key=' + GOODREADSAPI.DEVKEY + '&callback=p';
			
			var deferred = $q.defer();
			
			$http({
				method: 'GET',
				url: url
			}).then(
				function successCallback(xmlData) {
					deferred.resolve(xmlData);
				},
				function errorCallback(error) {
					deferred.reject(error);
				}
			);

			return deferred.promise;
		}
	}

})();