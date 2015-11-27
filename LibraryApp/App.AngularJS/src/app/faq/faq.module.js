(function () {
	'use strict';

	// register the route config on the application
	angular
		.module('ddsApp.faq', ['ui.router'])
		.config(configFAQRoute);

	// inject configFAQRoute dependencies
	configFAQRoute.$inject = ['$stateProvider', 'mainMenuProvider'];

	// route config function configuring the passed $stateProvider
	function configFAQRoute($stateProvider, mainMenuProvider) {
		var mainState = {
			name: 'faq',
			url: '/faq',
			authenticate: false,
			templateUrl: 'app/faq/faq.html',
			controller: 'FAQController',
			controllerAs: 'vm'
		};

		$stateProvider.state(mainState);

		mainMenuProvider.addMenuItem({
			name: 'FAQ',
			state: mainState.name,
			order: 3,
			icon: 'navigation:ic_menu_24px'
		});
	}

})();