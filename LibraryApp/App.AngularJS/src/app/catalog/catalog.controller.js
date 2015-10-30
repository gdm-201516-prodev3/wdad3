/**
 * @ngdoc controller
 * @name ddsApp.catalog.controller:CatalogController
 * @description
 * Controls mainly nothing currently
 */
(function() {
  'use strict';

  // register the controller as CatalogController
  angular
    .module('ddsApp.catalog')
    .controller('CatalogController', CatalogController);

  CatalogController.$inject = ['$timeout'];
  
  function CatalogController($timeout) {
    var vm = this;
  }
  
})();
