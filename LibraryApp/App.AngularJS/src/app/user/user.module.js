(function () {
	'use strict';

	// register the route config on the application
	angular
		.module('ddsApp.user', [
			'ui.router'
		])
		.config(configUserRoute);

	// inject configUserRoute dependencies
	configUserRoute.$inject = ['$stateProvider', 'mainMenuProvider'];

	// route config function configuring the passed $stateProvider
	function configUserRoute($stateProvider, mainMenuProvider) {
		var user = {
			name: 'user',
			url: '/user',
			abstract: true,
			authenticate: false,
			templateUrl: 'app/user/user.html',
			controller: 'UserController',
			controllerAs: 'vm'
		};
		
		var userDashboard  = {
            name: 'user.dashboard',
            parent: user,
            url: '/dashboard',
			data: {
				'selectedTab' : 0
			},
			authenticate: false,
            templateUrl: 'app/user/user.dashboard.html'
        };
		
		var userProfile  = {
            name: 'user.profile',
            parent: user,
            url: '/profile',
			data: {
				'selectedTab' : 1
			},
			authenticate: false,
            templateUrl: 'app/user/user.profile.html'
        };

		$stateProvider
			.state(user)
			.state(userDashboard)
			.state(userProfile);

		mainMenuProvider.addMenuItem({
			name: 'User',
			state: userDashboard.name,
			order: 2,
			icon: 'action:ic_face_24px'
		});
	}

})();