/**
 * @ngdoc controller
 * @name ddsApp.blog.controller:BlogController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  // register the controller as BlogController
  angular
    .module('ddsApp.blog')
    .controller('BlogController', BlogController);

  BlogController.$inject = ['$timeout'];
  
  function BlogController($timeout) {
    var vm = this;
  }
  
})();
