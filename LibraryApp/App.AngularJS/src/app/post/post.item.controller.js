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

  PostItemController.$inject = ['$timeout', 'post'];
  
  function PostItemController($timeout, post) {
    var vm = this;
    
    vm.post = post;
  }
  
})();
