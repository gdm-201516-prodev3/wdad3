(function(){
    'use strict';

    angular.module('ddsApp.catalog')
        .filter('iconForCatalogItemType', IconForCatalogItemType);
        
    IconForCatalogItemType.$inject = ['$sanitize'];

    function IconForCatalogItemType($sanitize){
        return function(type){
            var html = '';

            switch(type){
                case 'Bachelorproef':html = 'social:ic_school_24px';break;
                case 'Boek':html = 'action:ic_book_24px';break;
                case 'Artikel':html = 'action:ic_description_24px';break;
                case 'Handboek/Cursus':html = 'action:ic_account_balance_24px';break;
                case 'DVD':html = 'av:ic_album_24px';break;
                default:html = 'av:ic_web_asset_24px';break;
            }

            return $sanitize(html);
        };
    };

})();