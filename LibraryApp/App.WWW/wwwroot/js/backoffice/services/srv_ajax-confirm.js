/*
 * Programmed by Philippe De Pauw -Waterschoot
 * Version: 1.0
 * Last updated: 15-10-2015
 * Education license: only use in educationel institutions
 * 
 *  class="confirm-link"
    data-id="@library.Id" 
    data-name="@library.Name"
    data-cat = "library"
    data-action="delete"  
    data-update-target="#libraries-list"
    data-update-href=""
 */
var ConfirmService = (function ($) {

    var _dataId, _dataName, _dataCategory, _dataAction, _dataUpdateTarget, _dataUpdateHref;
    var _message;
    var _href;
    


    var _confirmLinkClass, _confirmDialogId;
    var self;

    ConfirmService.prototype.constructor = ConfirmService;
    function ConfirmService(linkClass, dialogId) {
        _confirmLinkClass = linkClass;
        _confirmDialogId = dialogId;
        self = this;
    }

    ConfirmService.prototype.registerModalHandlers = function () {
        $(_confirmDialogId).find('.btn-confirm').click(function (ev) {
            ev.preventDefault();

            $.ajaxPrefilter(
               function (options, localOptions, jqXHR) {
                   if (options.type !== "GET") {
                       var token = GetAntiForgeryToken(_dataUpdateTarget);
                       if (token !== null) {
                           options.data = "X-Requested-With=XMLHttpRequest" + (options.data === "") ? "" : "&" + options.data;
                           options.data = options.data + "&" + token.name + '=' + token.value;
                       }
                   }
               }
           );

            $.ajax({
                url: _href,
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    if (data.state === 1) {

                        if (window.AlertService) {
                            window.AlertService.showAlert('Success', data.message);
                        }

                        var itemContainer = $('[data-id="' + _dataCategory + '-' + data.id + '"]');

                        $(itemContainer).animate({ opacity: 0.4 }, 680, function () {
                            
                            if(_dataAction == 'delete') {
                                (this).remove();
                            }

                            $.get(_dataUpdateHref, function (data) {
                                $(_dataUpdateTarget).html(data);

                                self.registerClickHandlers();
                            });
                        });

                    } else {
                        if (window.AlertManager) {
                            window.AlertManager.showAlert('Error', data.message);
                        }
                    }
                }
            });

            $('#confirm-dialog').modal('hide');

            return false;
        });
    }

    ConfirmService.prototype.registerClickHandlers = function () {
        $(_confirmLinkClass).click(function (ev) {
            ev.preventDefault();

            _dataId = $(this).data('id');
            _dataName = $(this).data('name');
            _dataCategory = $(this).data('cat');
            _dataAction = $(this).data('action')
            _dataUpdateTarget = $(this).data('update-target');
            _dataUpdateHref = $(this).data('update-href');
            _href = $(this)[0].href;

            switch (_dataAction) {
                case 'delete':
                    _message = "Are you sure you want to delete the selected " + _dataCategory + ": " + _dataName + "?";
                    break;
                case 'lock':
                    _message = "Are you sure you want to lock the selected " + _dataCategory + ": " + _dataName + "?";
                    break;
                case 'unlock':
                    _message = "Are you sure you want to unlock the selected " + _dataCategory + ": " + _dataName + "?";
                    break;
                case 'softdelete':
                    _message = "Are you sure you want to soft-delete the selected " + _dataCategory + ": " + _dataName + "?";
                    break;
                case 'softundelete':
                    _message = "Are you sure you want to soft-undelete the selected " + _dataCategory + ": " + _dataName + "?";
                    break;
                case 'enabletwofactor':
                    _message = "Are you sure you want to enable the Two Factor Auth for the selected " + _dataCategory + ": " + _dataName + "?";
                    break;
                case 'disabletwofactor':
                    _message = "Are you sure you want to disable the Two Factor Auth for the selected " + _dataCategory + ": " + _dataName + "?";
                    break;
            }

            $(_confirmDialogId).find('.modal-body').html(_message);
            $(_confirmDialogId).modal('show');

            return false;
        });        
    };

    return ConfirmService;
})(jQuery);