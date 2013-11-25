(function ($) {
    $.validator.unobtrusive.adapters.add('lessthanorequaldate', ['other'], function (options) {
        var getModelPrefix = function (fieldName) {
            return fieldName.substr(0, fieldName.lastIndexOf(".") + 1);
        };

        var appendModelPrefix = function (value, prefix) {
            if (value.indexOf("*.") === 0) {
                value = value.replace("*.", prefix);
            }
            return value;
        };
        
        var prefix = getModelPrefix(options.element.name),
            other = options.params.other,
            fullOtherName = appendModelPrefix(other, prefix),
            element = $(options.form).find(":input[name=" + fullOtherName + "]")[0];

        options.rules['lessthanorequaldate'] = element;
        if (options.message != null) {
            options.messages['lessthanorequaldate'] = options.message;
        }
    });

    $.validator.addMethod('lessthanorequaldate', function (value, element, params) {
        var parseDate = function (date) {
            var m = date.match(/^(\d{4})-(\d{1,2})-(\d{1,2})$/);
            return m ? new Date(parseInt(m[1]), parseInt(m[2]) - 1, parseInt(m[3])) : null;
        };

        var date = parseDate(value);
        var dateToCompareAgainst = parseDate($(params).val());

        if (isNaN(date.getTime()) || isNaN(dateToCompareAgainst.getTime())) {
            return false;
        }

        return date <= dateToCompareAgainst;
    });

})(jQuery);