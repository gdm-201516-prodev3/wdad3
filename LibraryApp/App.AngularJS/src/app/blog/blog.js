(function () {
	'use strict';

	// register the route config on the application
	angular
		.module('ddsApp.blog', ['ui.router'])
		.config(configBlogRoute);

	// inject configBlogRoute dependencies
	configBlogRoute.$inject = ['$stateProvider', 'mainMenuProvider'];

	// route config function configuring the passed $stateProvider
	function configBlogRoute($stateProvider, mainMenuProvider) {
		var mainState = {
			name: 'blog',
			url: '/blog',
			authenticate: false,
			templateUrl: 'app/blog/blog.html',
			controller: 'BlogController',
			controllerAs: 'vm'
		};

		$stateProvider.state(mainState);

		mainMenuProvider.addMenuItem({
			name: 'Blog',
			state: mainState.name,
			order: 2,
			icon: 'navigation:ic_menu_24px'
		});
	}

})();