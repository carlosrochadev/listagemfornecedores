$(document).ready(function () {

    $(function () {
        $("#data-cadastro").datepicker({
            dateFormat: 'dd/mm/yy',
            dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
            dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
            dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
            monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            changeMonth: true,
            changeYear: true,
            maxDate: new Date(2019, 12, 31), // 1 de Janeiro de 1998
            minDate: new Date(1970,1,1 ), // 31 de Janeiro de 1998,
        });
    });

    $('#cpf-cnpj').on('keypress', function (e) {
        somenteNumeros(e)
    });

    $('#cpf-cnpj').on('keyup', function () {
        let valorCampo = $('#cpf-cnpj').val();

        if (valorCampo === undefined || valorCampo === '') {
            event.preventDefault();
            return;
        }

        let mascara = "";

        if (valorCampo.length <= 18) {
            mascara = MascaraCPF(valorCampo);
            $('#cpf-cnpj').val(mascara);
        }
        else {
            mascara = MascaraCNPJ(valorCampo)
            $('#cpf-cnpj').val(mascara.substring(0, 18));
        }
    });

    $('#data-cadastro').on('keypress', function () {
        somenteNumeros(e);
    });
});

function pesquisarFornecedor() {
    let host = window.location.host;

    if (host.indexOf('http') === -1) {
        host = "http://" + host + "/Fornecedor/PesquisarFornecedores"
    }

    $.ajax({
        url: host,
        type: "POST",
        data: { nome: $('#nome').val(), cpfcnpj: $('#cpf-cnpj').val(), dataCadastro: $('#data-cadastro').val()},
        success: function (data) {
            if (data.Fornecedores.length > 0) {
                $('table tbody tr').remove();
                for (var i = 0; i < data.Fornecedores.length; i++) {
                    $('table tbody:last').append('<tr><td>' + data.Fornecedores[i].Nome + '</td><td>' + data.Fornecedores[i].NomeEmpresa + '</td><td>' + data.Fornecedores[i].CPFCNPJ + '</td><td>' + data.Fornecedores[i].Telefone + '</td></tr>');
                }
            }
        },
        error: function () {
            alert('Ocorreu um erro ao realizar a pesquisa.');
        }
    });
}