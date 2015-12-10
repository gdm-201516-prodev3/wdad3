(function () {
	'use strict';

	// register the service as MainToolbar
	angular
		.module('ddsApp.comp-mainToolbar')
		.directive('mainToolbar', MainToolbar);

	// add MainToolbar dependencies to inject
	MainToolbar.$inject = ['$rootScope', '$mdSidenav', '$document'];

	/**
	 * MainMenu directive
	 */
	function MainToolbar($rootScope, $mdSidenav, $document) {
		// directive definition members
		var directive = {
			link: link,
			restrict: 'E',
			replace: true,
			templateUrl: 'app/components/main-toolbar/main-toolbar.html'
		};

		return directive;
		
		// directives link definition
		function link(scope, elem, attrs) {
			
		}
	}


})();
