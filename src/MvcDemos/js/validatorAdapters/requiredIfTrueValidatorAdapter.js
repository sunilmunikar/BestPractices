(function ($) {
    "use strict";
    
    jQuery.validator.addMethod('requirediftrue', function (value, element, params) {
        var checkboxId = $(element).attr('data-val-requirediftrue-boolprop');
        var checkboxValue = $('#' + checkboxId).first().is(":checked");
        return !checkboxValue || value;
    }, '');

    jQuery.validator.unobtrusive.adapters.add('requirediftrue', {}, function (options) {
        options.rules['requirediftrue'] = true;
        options.messages['requirediftrue'] = options.message;
    });

})(jQuery);