/*
 * Programmed by Philippe De Pauw -Waterschoot
 * Version: 1.0
 * Last updated: 15-10-2015
 * Education license: only use in educationel institutions!
 */
var AlertService = (function ($) {

    var _alertContainer;

    function AlertService(alertContainerSelector) {
        _alertContainer = $(alertContainerSelector);
    }

    AlertService.prototype.showAlert = function (type, message) {
        var content = ''
        + '<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">'
        + '<div class="alert ' + convertAlertTypeToBootstrapAlertType(type) + '">'
        + '<p>' + message + '</p>'
        + '</div>'
        + '</div>';
        _alertContainer.append(content);

        var alertElement = _alertContainer.children().last();

        window.setTimeout(function () {
            alertElement.fadeOut('slow', function () {
                $(this).remove();
            });
        }, 3000);
		
    };

    function convertAlertTypeToBootstrapAlertType(alertType) {
        switch (alertType) {
            case 'Success': default: return 'alert-success';
            case 'Info': return 'alert-info';
            case 'Warning': return 'alert-warning';
            case 'Error': return 'alert-danger';
        }
    };

    return AlertService;
	
})(jQuery);