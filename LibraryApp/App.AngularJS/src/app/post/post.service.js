/**
 * @ngdoc overview
 * @name auth.user
 * @description
 * The `ddsApp.post` module which provides:
 *
 * - {@link ...}
 * - {@link ...}
 *
 * @requires resource
 */

/**
 * @ngdoc service
 * @name ddsApp.post:Post
 * @description
 * Angular resource for handling communication with the api/posts route
 */

/**
 * @ngdoc service
 * @name ddsApp.post:PostService
 * @description
 * Service with function for dealing with posts
 */

(function () {
	'use strict';

	angular
		.module('ddsApp.post')
		.factory('Post', Post)
		.service('PostService', PostService);


	/**
	 * @ngdoc function
	 * @name ddsApp.post:User
	 * @description
	 * User resource constructor
	 *
	 * @param {Service} $resource The resource service to use
	 * @returns {Service} {@link ...}
	 */

	Post.$inject = ['$resource', 'LIBRARYAPPAPIURL'];

	function Post($resource, LIBRARYAPPAPIURL) {
		// factory members
		var apiURL = LIBRARYAPPAPIURL + '/posts/:post_id';
		
		var methods = { 
			update: {
				method: 'PUT',
				params: { post_id : '@id' }
			},
			get: {
				method: 'GET',
				params: { post_id : '@id' }
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
	 * @name ddsApp.post:PostService
	 * @description
	 * PostService constructor
	 * AngularJS will instantiate a singleton by calling "new" on this function
	 *
	 * @param {Service} Post The resource provided
	 * @returns {Service} {@link ...}
	 */

	PostService.$inject = ['Post'];

	function PostService(Post) {

		return {
			create: create,
			update: update,
			remove: remove
		};

		/**
		 * @ngdoc function
		 * @name create
		 * @methodOf ddsApp.post:PostService
		 * @description
		 * Save a new post
		 *
		 * @param {Object} post The postData to save
		 * @param {Function} [callback] A callback
		 * @returns {Promise} A promise
		 */
		function create(post, callback) {
			var cb = callback || angular.noop;

			return Post.create(post,
				function (post) {
					return cb(post);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}

		/**
		 * @ngdoc function
		 * @name remove
		 * @methodOf ddsApp.post:PostService
		 * @description
		 * Remove a post
		 *
		 * @param {Object} post The postData to remove
		 * @param {Function} [callback] A callback
		 * @return {Promise} A promise
		 */
		function remove(post, callback) {
			var cb = callback || angular.noop;

			return Post.remove({id: post._id},
				function (post) {
					return cb(post);
				},
				function (err) {
					return cb(post);
				}).$promise;
		}

		/**
		 * @ngdoc function
		 * @name update
		 * @methodOf ddsApp.post:PostService
		 * @description
		 * Update a post
		 *
		 * @param {Object} post The postData to update
		 * @param {Function} [callback] A callback
		 * @return {Promise} A promise
		 */
		function update(post, callback) {
			var cb = callback || angular.noop;

			return Post.update(post,
				function (post) {
					return cb(post);
				},
				function (err) {
					return cb(err);
				}).$promise;
		}
	}

})();
