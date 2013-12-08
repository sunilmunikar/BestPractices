'use strict';
var jqGridDemoModule = (function () {
    // Internal members
    var iffeId = 'jqgridDemoModule';
    var jqGridUrl = null;

    function init(url) {
        jqGridUrl = url;
        initJqGrid();
    }

    // Define the functions and properties to reveal
    var service = {
        init: init,
        getData: getData
    };

    return service;

    function getData() {

    }

    //#region Internal Methods        

    function initJqGrid() {
        jQuery("#list2").jqGrid({
            prmNames: { rows: 'pageSize', sort: 'sortColumn', order: 'sortOrder', sortExpression: 'sidx' },
            url: jqGridUrl,
            datatype: "json",
            mtype: 'POST',
            loadError: function (x, y, z) {
                var obj = jQuery.parseJSON(x.responseText);
                alert(obj);
            },
            jsonReader: {
                repeatitems: false
            },
            colNames: ['Inv No', 'Status', 'Date', 'Client', 'Amount', 'Tax', 'Total', 'Notes'],
            colModel: [
                { name: 'id', index: 'id', width: 55 },
                {name: 'requestStatus', stype:'select', searchoptions: {
                    value: ":All;1:Pending;2:Approved"
                }},
                { name: 'invdate', index: 'invdate', width: 90 },
                { name: 'name', index: 'name asc, invdate', width: 100 },
                { name: 'amount', index: 'amount', width: 80, align: "right" },
                { name: 'tax', index: 'tax', width: 80, align: "right" },
                { name: 'total', index: 'total', width: 80, align: "right" },
                { name: 'note', index: 'note', width: 150, sortable: false }
            ],
            autowidth: true,
            shrinkToFit: false,
            altRows: true,
            altclass: "alternate",
            height: 'auto',
            rowNum: 20,
            rowList: [10, 20, 40],
            sortname: 'id',
            sortorder: 'desc',
            pager: '#pager',

            viewrecords: true,
            caption: "JSON Example",
            loadtext: "Loading...",
            loadComplete: gridComplete
        }).filterToolbar();
        //jQuery("#list2")
        //    .jqGrid('navGrid', '#pager2', { edit: false, add: false, del: false });

    }

    function gridComplete() {
        console.log("load complete");
    }

    //#endregion

})();