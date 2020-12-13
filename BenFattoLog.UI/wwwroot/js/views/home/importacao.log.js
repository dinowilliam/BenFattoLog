let $table = $("#table");
let adicionar = document.querySelector("#add");
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
    return moment(value).format('DD/MM/YYYY HH:mm:ss ZZ');
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

    initTable();

    let inputFile = document.getElementById('arquivoLogImportacao');
    let inputLabel = document.getElementById('labelArquivoLogImportacao');
    inputFile.addEventListener('change', function () {
        inputLabel.innerHTML = inputFile.files[0].name;
    })


})

