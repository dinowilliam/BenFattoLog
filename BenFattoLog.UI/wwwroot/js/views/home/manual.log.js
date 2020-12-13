let $table = $("#table");
let $remove = $("#remove");
let adicionar = document.querySelector("#add");
let selections = []

class manualLogModal {

    constructor(modalId) {
        this.modal = new bootstrap.Modal(document.getElementById(modalId));

        this.modalId = modalId;
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

            this.saveModal.disabled = true;

            if (this.validateFields()) {
                const data = {
                    'id': document.querySelector("#id") && document.querySelector("#id").value ? document.querySelector("#id").value : null,
                    'ipAddress': document.querySelector("#ipAddress").value,
                    'occurrenceeDate': moment(document.querySelector("#occurenceeDate").value, 'DD/MM/YYYY HH:mm').format(),
                    'accessLog': document.querySelector("#httpVerb").value + ' ' + document.querySelector("#accessLog").value + ' ' + document.querySelector("#httpProtocol").value,
                    'httpResponse': Number(document.querySelector("#httpResponse").value),
                    'port': Number(document.querySelector("#port").value)
                }

                fetch('https://localhost:44386/api/log', {
                    method: 'PUT', // or 'POST'
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(data)
                })
                    .then(response => response.json())
                    .then(data => {
                        $table.bootstrapTable('refresh');
                        this.modal.hide();
                        this.saveModal.disabled = false;
                    })
                    .catch((error) => {
                        console.error('Error:', error);
                        this.saveModal.disabled = false;
                    });
            }
            else {
                this.saveModal.disabled = false;
            }

        });
    }

    validateFields() {
        var requiredFields = document.querySelector(`#${this.modalId}`).querySelectorAll("input:not([type=hidden]),select");

        requiredFields.forEach(element => {
            if (element && element.value) {
                element.classList.remove("is-invalid");
                element.classList.add("is-valid");
            }
            else {
                element.classList.remove("is-valid");
                element.classList.add("is-invalid");
            }

        });

        return document.querySelector(`#${this.modalId}`).querySelectorAll(".is-invalid").length > 0 ? false : true;
    }

    showModal() {
        this.modal.show();
    }

    closeModal() {
        this.modal.hide();
    }
}

function cleanFields() {
    var cleanFields = document.querySelector("#manualLogModal").querySelectorAll("input:not([type=hidden]),select");

    cleanFields.forEach(element => {

        element.classList.remove("is-invalid", "is-valid");

    });

    document.querySelector("#id").value = "";
    document.querySelector("#ipAddress").value = "";
    document.querySelector("#occurenceeDate").value = moment(new Date()).format('DD/MM/YYYY HH:mm');
    document.getElementById("httpVerb").selectedIndex = 1;
    document.querySelector("#accessLog").value = "";
    document.getElementById("httpProtocol").selectedIndex = 1;
    document.querySelector("#httpResponse").value = "";
    document.querySelector("#port").value = "";

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
        '<a class="update" href="javascript:void(0)" title="Like">',
        '<i class="fa fa-pen-alt"></i>',
        '</a>  ',
        '<a class="remove" href="javascript:void(0)" title="Remove">',
        '<i class="fa fa-trash"></i>',
        '</a>'
    ].join('')
}

window.operateEvents = {
    'click .update': function (e, value, row, index) {

        var cleanFields = document.querySelector("#manualLogModal").querySelectorAll("input:not([type=hidden]),select");
        cleanFields.forEach(element => {
            element.classList.remove("is-invalid", "is-valid");
        });

        var accessLogSring = row.accessLog.replace(/GET|POST|PUT|DELETE|/g, "");
        accessLogSring = accessLogSring.trim().substring(0, accessLogSring.trim().length - 8);

        document.querySelector("#id").value = row.id;
        document.querySelector("#ipAddress").value = row.ipAddress;
        document.querySelector("#occurenceeDate").value = moment(row.occurenceeDate).format('DD/MM/YYYY HH:mm');
        document.querySelector("#httpVerb").value = row.accessLog.substring(0, row.accessLog.indexOf(' '));
        document.querySelector("#httpProtocol").value = row.accessLog.substring(row.accessLog.trim().length - 8, row.accessLog.trim().length);
        document.querySelector("#accessLog").value = accessLogSring;
        document.querySelector("#httpResponse").value = row.httpResponse;
        document.querySelector("#port").value = row.port;

        let manualLogUpdate = new manualLogModal('manualLogModal');
        manualLogUpdate.showModal();

    },
    'click .remove': function (e, value, row, index) {

        if (confirm('Você tem certeza que deseja exlcuir esse registro?')) {


            var id = row.id;

            fetch(`https://localhost:44386/api/log/${id}`, {
                method: 'DELETE', // or 'POST'
            })
                .then(response => response.json())
                .then(data => {
                    $table.bootstrapTable('remove', {
                        field: 'id',
                        values: [row.id]
                    })

                    $table.bootstrapTable('refresh');

                })
                .catch((error) => {
                    console.error('Error:', error);
                });
        }

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
            }, {
                field: 'operate',
                title: 'Operações',
                align: 'center',
                clickToSelect: false,
                events: window.operateEvents,
                formatter: operateFormatter
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

    $("#httpResponse").inputmask("numeric", { min: 100, max: 599 });

    $("#port").inputmask("numeric", { min: 0, max: 65535 });

    initTable();
    let manualLog = new manualLogModal('manualLogModal');

    let modalFocus = document.getElementById('manualLogModal');
    let inputFocus = document.getElementById('ipAddress');

    modalFocus.addEventListener('shown.bs.modal', function () {
        inputFocus.focus();
    })

    adicionar.addEventListener('click', function (event) {
        cleanFields();
        manualLog.showModal();
    })



})

