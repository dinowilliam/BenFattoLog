let $table = $("#table");
let inputFile = document.getElementById('arquivoLogImportacao');
let inputLabel = document.getElementById('labelArquivoLogImportacao');
let spinnersFileInput = document.getElementById('spinnersFileInput');
let enviar = document.getElementById('enviar');
let servicePort = 44386;
let serviceAddress = 'https://localhost:'

let selections = []

function cleanFields() {


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
        url: `${serviceAddress}${servicePort}/api/log`,
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

    initTable();


    inputFile.addEventListener('change', function () {
        inputLabel.innerHTML = inputFile.files[0].name;
    })



    enviar.addEventListener('click', function (event) {
        cleanFields();

        enviar.disabled = true;
        spinnersFileInput.classList.remove("d-none");

        const formData = new FormData();

        formData.append('files', inputFile.files[0]);

        fetch(`${serviceAddress}${servicePort}/api/log/upload`, {
            method: 'PUT',
            body: formData
        })
            .then(response => response.json())
            .then(result => {
                console.log('Success:', result);
                enviar.disabled = false;
                spinnersFileInput.classList.add("d-none");
                $table.bootstrapTable('refresh');
            })
            .catch(error => {
                console.error('Error:', error);
                enviar.disabled = false;
                spinnersFileInput.classList.add("d-none");
            });
    })


})

