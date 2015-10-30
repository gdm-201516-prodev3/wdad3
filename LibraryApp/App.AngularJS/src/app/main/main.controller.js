/**
 * @ngdoc controller
 * @name ddsApp.main.controller:MainController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  // register the controller as MainController
  angular
    .module('ddsApp.main')
    .controller('MainController', MainController);

  MainController.$inject = ['$timeout'];
  
  function MainController($timeout) {
    var vm = this;
  }
  
})();
