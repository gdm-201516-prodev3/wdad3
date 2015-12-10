/**
 * @ngdoc overview
 * @name auth.user
 * @description
 * The `ddsApp.faq` module which provides:
 *
 * - {@link ...}
 * - {@link ...}
 *
 * @requires resource
 */

/**
 * @ngdoc service
 * @name ddsApp.faq:FAQ
 * @description
 * Angular resource for handling communication with the api/posts route
 */

/**
 * @ngdoc service
 * @name ddsApp.faq:FAQService
 * @description
 * Service with function for dealing with faqs
 */

(function () {
	'use strict';

	angular
		.module('ddsApp.faq')
		.factory('FAQ', FAQ)
		.service('FAQService', FAQService);


	/**
	 * @ngdoc function
	 * @name ddsApp.faq:FAQ
	 * @description
	 * User resource constructor
	 *
	 * @param {Service} $resource The resource service to use
	 * @returns {Service} {@link ...}
	 */

	FAQ.$inject = ['$resource', 'LIBRARYAPPAPIURL'];

	function FAQ($resource, LIBRARYAPPAPIURL) {
		// factory members
		var apiURL = LIBRARYAPPAPIURL + '/faqs/:faq_id';
		
		var methods = { 
			update: {
				method: 'PUT',
				params: { faq_id : '@id' }
			},
			get: {
				method: 'GET',
				params: { faq_id : '@id' }
			},
			query: { 
				method: "GET", 
				isArray: true 
			}
		};

		return $resource(apiURL, {}, methods);
	}


	/**
	 * @ngdoc function
	 * @name ddsApp.faq:FAQService
	 * @description
	 * FAQService constructor
	 * AngularJS will instantiate a singleton by calling "new" on this function
	 *
	 * @param {Service} FAQ The resource provided
	 * @returns {Service} {@link ...}
	 */

	FAQService.$inject = ['FAQ'];

	function FAQService(FAQ) {

		return {
			create: create,
			update: update,
			remove: remove
		};

		/**
		 * @ngdoc function
		 * @name create
		 * @methodOf ddsApp.faq:FAQService
		 * @description
		 * Save a new faq
		 *
		 * @param {Object} faq The postData to save
		 * @param {Function} [callback] A callback
		 * @returns {Promise} A promise
		 */
		function create(faq, callback) {
			var cb = callback || angular.noop;

			return FAQ.create(faq,
				function (faq) {
					return cb(faq);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}

		/**
		 * @ngdoc function
		 * @name remove
		 * @methodOf ddsApp.faq:FAQService
		 * @description
		 * Remove a faq
		 *
		 * @param {Object} faq The postData to remove
		 * @param {Function} [callback] A callback
		 * @return {Promise} A promise
		 */
		function remove(faq, callback) {
			var cb = callback || angular.noop;

			return FAQ.remove({id: faq._id},
				function (faq) {
					return cb(faq);
				},
				function (err) {
					return cb(faq);
				}).$promise;
		}

		/**
		 * @ngdoc function
		 * @name update
		 * @methodOf ddsApp.faq:FAQService
		 * @description
		 * Update a faq
		 *
		 * @param {Object} faq The postData to update
		 * @param {Function} [callback] A callback
		 * @return {Promise} A promise
		 */
		function update(faq, callback) {
			var cb = callback || angular.noop;

			return FAQ.update(faq,
				function (faq) {
					return cb(faq);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}
	}

})();
