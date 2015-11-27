/**
 * @ngdoc controller
 * @name ddsApp.post:PostController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  // register the controller as PostController
  angular
    .module('ddsApp.post')
    .controller('PostController', PostController);

  // Inject dependencies
  PostController.$inject = ['$timeout', 'Post'];
  
  function PostController($timeout, Post) {
    var vm = this;
    
    vm.posts = Post.query({libraryId:3}, function(data) {
      console.log(data);
    });
  }
  
})();
