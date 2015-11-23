/**
 * @ngdoc controller
 * @name ddsApp.blog.controller:PostController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  // register the controller as PostController
  angular
    .module('ddsApp.post')
    .controller('BlogController', PostController);

  PostController.$inject = ['$timeout'];
  
  function PostController($timeout) {
    var vm = this;
  }
  
})();
