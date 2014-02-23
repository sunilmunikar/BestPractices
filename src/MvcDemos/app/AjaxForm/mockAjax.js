(function ($) {
    $.mockjax({
        url: '/restful/mockAjaxCall',
        responseTime: 750,
        responseText: {
            status: 'success',
            message: 'returned message from mocked ajax call'
        }
        //,
        //responseText: $.mockJSON.generateFromTemplate({
        //    "contacts|50-500": [{
        //        "married|0-1": true,
        //        "email": "@EMAIL",
        //        "firstName": "@MALE_FIRST_NAME",
        //        "lastName": "@LAST_NAME",
        //        "birthday": "@DATE_MM/@DATE_DD/@DATE_YYYY",
        //        "percentHealth|0-100": 0
        //    }]
    });

    $(".trigger").click(function () {
        $.getJSON('/restful/mockAjaxCall', function (response) {
            if (response.status == 'success') {
                $('#messageFromMockedAjax').html('Your message from MockedAjax is: ' + response.message);
            } else {
                $('#messageFromMockedAjax').html('Things do not look good.');
            }
        });
    });

    function BoolCellFormatter(row, cell, value, columnDef, dataContext) {
        return value ? "✔" : "";
    };

}(jQuery));
