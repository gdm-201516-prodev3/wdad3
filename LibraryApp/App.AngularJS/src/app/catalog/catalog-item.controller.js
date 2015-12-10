/**
 * @ngdoc controller
 * @name ddsApp.catalog:CatalogDetailsController
 * @description
 * Controls mainly nothing currently
 * API search: http://localhost:8081/api/libraryitems/arrivals?LibraryCode=MAR&ItemsPerPage=20&Offset=20&SortOrder=0&DaysAge=20
 */
(function() {
  'use strict';

  // register the controller as CatalogItemController
  angular
    .module('ddsApp.catalog')
    .controller('CatalogItemController', CatalogItemController);

  CatalogItemController.$inject = ['$timeout', 'catalogItem', 'GoogleBooksService'];
  
  function CatalogItemController($timeout, catalogItem, GoogleBooksService) {
    var vm = this;
    console.log(catalogItem);
    vm.catalogItem = catalogItem;
    
    var isbn = catalogItem.isbn;
    if(isbn != null && isbn != '') {
      isbn = isbn.replace(/\D/g, '');
      
      GoogleBooksService.getBookByISBN(isbn).then(
        function(data) {
          vm.googlebook = data;
          vm.googlebook.volumeInfo.imageLinks.thumbnailMedium = vm.googlebook.volumeInfo.imageLinks.thumbnail.replace(/(zoom=)[^\&]+/, '$1' + '2');
          vm.googlebook.volumeInfo.imageLinks.thumbnailLarge = vm.googlebook.volumeInfo.imageLinks.thumbnail.replace(/(zoom=)[^\&]+/, '$1' + '3');
        },
        function(error) {
          
        }
      );
    }
  }
  
})();
