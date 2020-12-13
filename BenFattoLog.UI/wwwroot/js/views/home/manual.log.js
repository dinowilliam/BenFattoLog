let $table = $("#table");
let $remove = $("#remove");
let adicionar = document.querySelector("#add");
let selections = []

class manualLogModal {

    constructor(modalId) {
        this.modal = new bootstrap.Modal(document.getElementById(modalId));

        this.defineButtons();
        this.bindEvents();
    }

    defineButtons() {
        this.closeModalTitle = document.querySelector("#closeModalTitle");
        this.closeModal = document.querySelector("#closeModal");
        this.saveModal = document.querySelector("#saveModal");
    }

    bindEvents() {
        closeModalTitle.addEventListener('click', (event) => {
            this.modal.hide();
        });

        closeModal.addEventListener('click', (event) => {
            this.modal.hide();
        });

        saveModal.addEventListener('click', (event) => {

            const data = {
                'ipAddress': document.querySelector("#ip").value,
                'occurrenceeDate': document.querySelector("#occurenceeDate").value,
                'accessLog': document.querySelector("#httpVerb").value + ' ' + document.querySelector("#accessLog").value + ' ' + document.querySelector("#httpProtocol").value,
                'httpResponse': document.querySelector("#httpResponse").value,
                'port': document.querySelector("#port").value
            }

            fetch('https://localhost:44386/api/log', {
                method: 'PUT', // or 'POST'
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            })
                .then(response => response.json())
                .then(data => {
                    console.log('Success:', data);
                })
                .catch((error) => {
                    console.error('Error:', error);
                });

        });
    }

    showModal() {
        this.modal.show();
    }

    closeModal() {
        this.modal.hide();
    }
}

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

function dateFormatter(value, row, index) {
    return moment(value).format('DD/MM/YYYY HH:mm:ss ZZ');
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
                title: 'Ip',
                field: 'ipAddress',
                rowspan: 1,
                align: 'center',
                valign: 'middle',
                sortable: true,
            }, {
                field: 'occurrenceeDate',
                title: 'Data da Ocorrência',
                rowspan: 1,
                sortable: true,
                align: 'center',
                formatter: dateFormatter
            }, {
                field: 'accessLog',
                title: 'Log de Acesso',
                rowspan: 1,
                sortable: true,
                align: 'center',
            }, {
                field: 'httpResponse',
                title: 'Resposta HTTP',
                align: 'center',
                rowspan: 1

            }, {
                field: 'port',
                title: 'Porta',
                align: 'center',
                rowspan: 1
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

$(() => {

    $(":input").inputmask();

    $('#occurenceeDate').inputmask("datetime", {
        inputFormat: "dd/mm/yyyy HH:MM",
        placeholder: "DD/MM/AAAA HH:MM",
        leapday: "-02-29",
        alias: "datetime"
    });

    $("#port").inputmask("numeric", { min: 0, max: 65535 });

    initTable();

    let manualLog = new manualLogModal('manualLogModal');

    let modalFocus = document.getElementById('manualLogModal');
    let inputFocus = document.getElementById('ip');

    modalFocus.addEventListener('shown.bs.modal', function () {
        inputFocus.focus();
    })

    adicionar.addEventListener('click', function (event) {
        manualLog.showModal();
    })



})

