(function () {
	'use strict';

	// register the route config on the application
	angular
		.module('ddsApp.post', [
			'ui.router'
		])
		.config(configPostRoute);

	// inject configPostRoute dependencies
	configPostRoute.$inject = ['$stateProvider', 'mainMenuProvider'];

	// route config function configuring the passed $stateProvider
	function configPostRoute($stateProvider, mainMenuProvider) {
		var mainState = {
			name: 'post',
			url: '/post',
			authenticate: false,
			templateUrl: 'app/post/templates/post.list.html',
			controller: 'PostController',
			controllerAs: 'vm'
		};

		$stateProvider.state(mainState);

		mainMenuProvider.addMenuItem({
			name: 'Post',
			state: mainState.name,
			order: 2,
			icon: 'navigation:ic_menu_24px'
		});
	}

})();