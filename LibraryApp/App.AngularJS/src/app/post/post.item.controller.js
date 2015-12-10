/**
 * @ngdoc controller
 * @name ddsApp.post:PostItemController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  angular
    .module('ddsApp.post')
    .controller('PostItemController', PostItemController);

  PostItemController.$inject = ['$timeout'];
  
  function PostItemController($timeout) {
    var vm = this;
    
    console.log('sla');
  }
  
})();
