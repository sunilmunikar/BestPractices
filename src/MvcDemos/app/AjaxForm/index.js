'use strict';
var index = (function() {
    // Internal members
    var iffeId = 'index';

    // Define the functions and properties to reveal
    var service = {
        init: init
    };

    return service;

    function init() {
        $("#dialog-form").dialog();

        $("#create-user")
            .button()
            .click(function() {
                $("#dialog-form").dialog("open");
            });
    }

    //#region Internal Methods        

    //#endregion
})();