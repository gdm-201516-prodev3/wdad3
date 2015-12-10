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

  CatalogController.$inject = ['$timeout', '$scope', 'CatalogService'];
  
  function CatalogController($timeout, $scope, CatalogService) {
    var vm = this;

    $scope.$on('$stateChangeSuccess', function(event, toState) {
        if(toState.data != null && typeof toState.data != undefined) {
          vm.currentTab = toState.data.selectedTab;
        }
    });
    
    // http://localhost:8081/api/libraryitems/arrivals?LibraryCode=MAR&ItemsPerPage=20&Offset=20&SortOrder=0&DaysAge=20
    // Search for arrivals
    vm.searchArrivals = {
      "LibraryCode": "MAR",
      "ItemsPerPage": 20,
      "Offset": 0,
      "SortOrder": 0,
      "DaysAge": 20
    }
    
    vm.pagingArrivals = {
      "Page": 1,
      "PageCount": 1
    }

    // Search Next Catalog Arrivals (Paging by Endless Scrolling)
    vm.getNextCatalogArrivals = function(page) {
      getCatalogArrivals(page);
    }
    
    // Get arrivals
    function getCatalogArrivals(page) {
      vm.searchArrivals.Offset = vm.searchArrivals.ItemsPerPage*(page - 1);
      CatalogService.getCatalogArrivals(vm.searchArrivals,
        function(data) {
          vm.catalogArrivals = data.items;
          vm.pagingArrivals.Page = data.pageNumber;
          vm.pagingArrivals.PageCount = data.pageCount;
        },
        function(error) {
          
        }
      );
    }
    
    vm.catalogArrivals = null;
    
    if(vm.catalogArrivals == null) {
      // Startup
      getCatalogArrivals(1);
    }
    
    // http://localhost:8081/api/libraryitems?LibraryCode=MAR&SearchField=JavaScript&ItemsPerPage=60&Offset=0&SortOrder=0
    // Search for items
    vm.searchItems = {
      "LibraryCode": "MAR",
      "ItemsPerPage": 20,
      "Offset": 0,
      "SortOrder": 0,
      "SearchField": ""
    }
    
    vm.pagingItems = {
      "Page": 1,
      "PageCount": 1
    }
    
    if(vm.sortOrders == null) {
      CatalogService.getCatalogSortOrders().then(
        function(data) {
          vm.sortOrders = data;
        }
      );
    }
    
    // Search catalog
    vm.getCatalogItems = function(){
      getCatalogItems(1);
    }

    // Search Next Catalog Items (Paging by Endless Scrolling)
    vm.getNextCatalogItems = function(page) {
      getCatalogItems(page);
    }
    
    function getCatalogItems(page) {
      vm.searchItems.Offset = vm.searchItems.ItemsPerPage*(page - 1);
      CatalogService.getCatalogItems(vm.searchItems,
        function(data) {
          vm.catalogItems = (page == 1)?data.items:vm.catalogItems.concat(data.items);
          vm.pagingItems.Page = page;
          vm.pagingItems.PageCount = data.pageCount;
        },
        function(error) {
          
        }
      );
    }
  }
  
})();
