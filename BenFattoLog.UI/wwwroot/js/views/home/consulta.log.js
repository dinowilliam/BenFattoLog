let $table = $("#table");
let inputFile = document.getElementById('arquivoLogImportacao');
let inputLabel = document.getElementById('labelArquivoLogImportacao');
let spinnersFileInput = document.getElementById('spinnersFileInput');
let pesquisar = document.getElementById('pesquisar');
let servicePort = 44386;
let serviceAddress = 'https://localhost:'

let selections = []

function cleanFields() {


}


function validateFields() {
    var requiredFields = document.querySelectorAll(".required-val");

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

    return document.querySelectorAll(".is-invalid").length > 0 ? false : true;
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
    return moment(value).format('DD/MM/YYYY HH:mm');
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
                align: 'center'
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
}

$(() => {
    $(":input").inputmask();

    $('#initialDate').inputmask("datetime", {
        inputFormat: "dd/mm/yyyy HH:MM",
        placeholder: "DD/MM/AAAA HH:MM",
        leapday: "-02-29",
        alias: "datetime"
    });

    $('#finalDate').inputmask("datetime", {
        inputFormat: "dd/mm/yyyy HH:MM",
        placeholder: "DD/MM/AAAA HH:MM",
        leapday: "-02-29",
        alias: "datetime"
    });

    initTable();

    pesquisar.addEventListener('click', function (event) {
        cleanFields();

        if (validateFields()) {
            pesquisar.disabled = true;
            spinnersFileInput.classList.remove("d-none");

            const data = {
                'ipAddress': document.querySelector("#ipAddress").value,
                'initialDate': moment(document.querySelector("#initialDate").value, 'DD/MM/YYYY HH:mm').format(),
                'finalDate': moment(document.querySelector("#finalDate").value, 'DD/MM/YYYY HH:mm').format(),
                'userAgent': document.querySelector("#userAgent").value
            }

            fetch(`${serviceAddress}${servicePort}/api/log/search`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data)
            })
                .then(response => response.json())
                .then(result => {

                    pesquisar.disabled = false;
                    spinnersFileInput.classList.add("d-none");

                    $table.bootstrapTable('load', result);
                })
                .catch(error => {
                    console.error('Error:', error);
                    enviar.disabled = false;
                    spinnersFileInput.classList.add("d-none");
                });
        }
    })


})

