(function () {
	'use strict';

	// register the route config on the application
	angular
		.module('ddsApp.post', [
			'ui.router',
			'ngResource'
		])
		.config(configPostRoute);

	// inject configPostRoute dependencies
	configPostRoute.$inject = ['$stateProvider', 'mainMenuProvider'];

	// route config function configuring the passed $stateProvider
	function configPostRoute($stateProvider, mainMenuProvider) {
		var post = {
			name: 'post',
			url: '/post',
			authenticate: false,
			templateUrl: 'app/post/post.list.html',
			controller: 'PostController',
			controllerAs: 'vm'
		};
		
		var postItemDetails = {
            name: 'post.details',
            parent: post,
            url: '/:postId',
            template: 'app/post/post.details.html',
			Controller: 'PostItemController',
            controllerAs: 'vm',
        };

		$stateProvider
			.state(post)
			.state(postItemDetails);

		mainMenuProvider.addMenuItem({
			name: 'Post',
			state: post.name,
			order: 2,
			icon: 'action:ic_description_24px'
		});
	}

})();