/**
 * @ngdoc controller
 * @name ddsApp.user.controller:UserController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  // register the controller as UserController
  angular
    .module('ddsApp.user')
    .controller('UserController', UserController);

  UserController.$inject = ['$timeout', '$scope'];
  
  function UserController($timeout, $scope) {
    var vm = this;

    $scope.$on('$stateChangeSuccess', function(event, toState) {
        if(toState.data != null && typeof toState.data != undefined) {
          vm.currentTab = toState.data.selectedTab;
        }
    });
    
  }
  
})();
