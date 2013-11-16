var index = (function () {
    'use strict';

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
            .click(function () {
                $("#dialog-form").dialog("open");
            });
    }

    //#region Internal Methods        

    //#endregion
})();

//http://www.kendoui.com/blogs/teamblog/posts/13-11-12/how-to-do-javascript-alerts-without-being-a-jerk.aspx
window.JqueryDialog = (function () {

    //create modal window on the fly

    var win = $("<div>").dialog({
        buttons: [{
            text: "Ok",
            click: function () {
                $(this).dialog("close");
            }
        }],
        autoOpen: false,
        closeOnEscape:true
    });

    return function (msg, deactivate) {
        if (deactivate) {
            win.bind("dialogclose", deactivate);
        } else
            win.unbind("dialogclose", deactivate);

        win.dialog("open");
    };

}());