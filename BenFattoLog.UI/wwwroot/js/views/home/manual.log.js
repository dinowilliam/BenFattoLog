let $table = $("#table");
let $remove = $("#remove");
let adicionar = document.querySelector("#add");
let modalAdicionar = new bootstrap.Modal(document.getElementById('exampleModal'));
let selections = []

function getIdSelections() {
    return $.map($table.bootstrapTable('getSelections'), function (row) {
        return row.id
    })
}

function responseHandler(res) {
    $.each(res.rows, function (i, row) {
        row.state = $.inArray(row.id, selections) !== -1
    })
    return res
}

function operateFormatter(value, row, index) {
    return [
        '<a class="like" href="javascript:void(0)" title="Like">',
        '<i class="fa fa-heart"></i>',
        '</a>  ',
        '<a class="remove" href="javascript:void(0)" title="Remove">',
        '<i class="fa fa-trash"></i>',
        '</a>'
    ].join('')
}

window.operateEvents = {
    'click .like': function (e, value, row, index) {
        alert('You click like action, row: ' + JSON.stringify(row))
    },
    'click .remove': function (e, value, row, index) {
        $table.bootstrapTable('remove', {
            field: 'id',
            values: [row.id]
        })
    }
}


function initTable() {
    $table.bootstrapTable('destroy').bootstrapTable({
        height: 750,
        locale: 'pt-BR',
        columns: [
            [{
                title: 'Item ID',
                field: 'id',
                rowspan: 1,
                align: 'center',
                valign: 'middle',
                sortable: true,
            }, {
                field: 'name',
                title: 'Item Name',
                rowspan: 1,
                sortable: true,
                align: 'center'
            }, {
                field: 'price',
                title: 'Item Price',
                rowspan: 1,
                sortable: true,
                align: 'center',
            }, {
                field: 'operate',
                title: 'Item Operate',
                align: 'center',
                rowspan: 1,
                clickToSelect: false,
                events: window.operateEvents,
            }]
        ]
    })
    $table.on('check.bs.table uncheck.bs.table ' +
        'check-all.bs.table uncheck-all.bs.table',
        function () {
            $remove.prop('disabled', !$table.bootstrapTable('getSelections').length)

            // save your data, here just save the current page
            selections = getIdSelections()
            // push or splice the selections if you want to save all data selections
        })
    $table.on('all.bs.table', function (e, name, args) {
        console.log(name, args)
    })

    $remove.click(function () {
        var ids = getIdSelections()
        $table.bootstrapTable('remove', {
            field: 'id',
            values: ids
        })
        $remove.prop('disabled', true)
    })
}

$(function () {
    initTable();

    adicionar.addEventListener('click', function (event) {
        modalAdicionar.show();
    })


})

