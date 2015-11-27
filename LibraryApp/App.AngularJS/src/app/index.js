/**
 * @ngdoc overview
 * @name ddsApp
 * @description
 * Module definition for the ddsApp module.
 */
(function() {
  'use strict';

  angular
    .module('ddsApp', [
      'ngAnimate', 
      'ngCookies', 
      'ngTouch', 
      'ngSanitize', 
      'ngMessages', 
      'ngAria', 
      'ngResource', 
      'ui.router', 
      'ngMaterial', 
      'toastr',
      'ddsApp.mainMenu',
      'ddsApp.catalog',
      'ddsApp.post',
      'ddsApp.faq',
      'ddsApp.main'
    ])
    .constant('LIBRARYAPPAPIURL', 'http://localhost:8081/api')
		.config(appConfig)
		.run(appRun);
   
    /* App configuration */

	  // add appConfig dependencies to inject
	  appConfig.$inject = ['$urlRouterProvider', '$urlMatcherFactoryProvider', '$locationProvider', '$mdThemingProvider', '$mdIconProvider', '$httpProvider'];

    /**
    * Application config function
    *
    * @param $stateProvider
    * @param $urlRouterProvider
    * @param $locationProvider
    */
    function appConfig($urlRouterProvider, $urlMatcherFactoryProvider, $locationProvider, $mdThemingProvider, $mdIconProvider, $httpProvider) {
      $urlRouterProvider.otherwise('/');
      $urlMatcherFactoryProvider.strictMode(false);
      $locationProvider.html5Mode(true);
      
      // Enable CORS (Cross-Origin Resource Sharing)
      $httpProvider.defaults.useXDomain = true;
      delete $httpProvider.defaults.headers.common['X-Requested-With'];
      
      //$httpProvider.interceptors.push('AuthInterceptor');
      
      
      // set the default palette name
      var defaultPalette = 'blue';
      // define a palette to darken the background of components
      var greyBackgroundMap = $mdThemingProvider.extendPalette(defaultPalette, {'A100': 'fafafa'});
      
      $mdThemingProvider.definePalette('grey-background', greyBackgroundMap);
      $mdThemingProvider.setDefaultTheme(defaultPalette);
      
      // customize the theme
      $mdThemingProvider
        .theme(defaultPalette)
        .primaryPalette(defaultPalette)
        .accentPalette('pink')
        .backgroundPalette('grey-background');
      
      var spritePath = 'bower_components/material-design-icons/sprites/svg-sprite/';
      $mdIconProvider.iconSet('navigation', spritePath + 'svg-sprite-navigation.svg');
      $mdIconProvider.iconSet('action', spritePath + 'svg-sprite-action.svg');
      $mdIconProvider.iconSet('content', spritePath + 'svg-sprite-content.svg');
      $mdIconProvider.iconSet('toggle', spritePath + 'svg-sprite-toggle.svg');
      $mdIconProvider.iconSet('alert', spritePath + 'svg-sprite-alert.svg');
    }
    
    /* App run bootstrap */

    // add appConfig dependencies to inject
    appRun.$inject = ['$rootScope', '$location', '$http'];
    
    /**
    * Application run function
    *
    * @param $rootScope
    * @param $location
    * @param Auth
    */
    function appRun($rootScope, $location, $http) {
  
      // Redirect to login if route requires auth and you're not logged in
      /*$rootScope.$on('$stateChangeStart', function (event, next) {
        if (!next.authenticate) {
          return;
        }
        
        Auth.isLoggedInAsync(function (loggedIn) {
          if (!loggedIn || next.role && !Auth.hasRole(next.role)) {
            $location.path('/login');
          }
        });
      });*/
    };

})();
