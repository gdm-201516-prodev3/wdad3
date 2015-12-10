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
		var faq = {
			name: 'faq',
			url: '/faq',
			authenticate: false,
			templateUrl: 'app/faq/faq.list.html',
			controller: 'FAQController',
			controllerAs: 'vm'
		};

		$stateProvider
			.state(faq);

		mainMenuProvider.addMenuItem({
			name: 'FAQ',
			state: faq.name,
			order: 3,
			icon: 'action:ic_question_answer_24px'
		});
	}

})();