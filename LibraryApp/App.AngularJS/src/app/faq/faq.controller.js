/**
 * @ngdoc controller
 * @name ddsApp.faq.controller:FAQController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  // register the controller as FAQController
  angular
    .module('ddsApp.faq')
    .controller('FAQController', FAQController);

  FAQController.$inject = ['$timeout'];
  
  function FAQController($timeout) {
    var vm = this;
  }
  
})();
