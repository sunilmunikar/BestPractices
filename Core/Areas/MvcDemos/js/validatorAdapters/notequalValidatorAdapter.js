// NotEqual
(function ($) {
    $.validator.addMethod("notequal", function (value, element, param) {
        return this.optional(element) || value != $(param).val();
    }, "This has to be different...");

    $.validator.unobtrusive.adapters.add("notequal", ["field"], function (options) {
        options.rules["notequal"] = options.params.field;
        if (options.message) options.messages["notequal"] = options.message;
    });
})(jQuery);