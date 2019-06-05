$(document).ready(function () {

    $(function () {
        $("#DataNascimento").datepicker({
            dateFormat: 'dd/mm/yy',
            dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
            dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
            dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
            monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            changeMonth: true,
            changeYear: true
        });
    });

    $('.glyphicon-plus').on('click', function () {
        var telefone = $('#Telefone').val();

        if (telefone === "") {
            alert('Informe um telefone');
        }
        else {
            adicionarTelefone(telefone);
        }
    });

    $('#CPFCNPJ').on('keypress', function (e) {
        somenteNumeros(e);
    });

    $('#CPFCNPJ').on('blur', function () {
        let valorCampo = $('#CPFCNPJ').val();

        if (valorCampo === undefined || valorCampo === '') {
            event.preventDefault();
            return;
        }

        let mascara ="";

        if (valorCampo.length <= 18) {
            mascara = MascaraCPF(valorCampo);
            $('#CPFCNPJ').val(mascara);
        }
        else {
            mascara = MascaraCNPJ(valorCampo)
            $('#CPFCNPJ').val(mascara.substring(0, 18));
        }
    });

    $('#RG').on('keypress', function (e) {
        somenteNumeros(e);
    });

    $('#RG').on('blur', function () {
        let valorCampo = $('#RG').val();

        if (valorCampo === undefined || valorCampo === '') {
            event.preventDefault();
            return;
        }

        let mascara = MascaraRG(valorCampo);
        $('#RG').val(mascara);
        
    });

    function adicionarTelefone(telefone) {
        let host = window.location.host;
        let indice = $('table tbody tr td').length + 1;
        let identificador = "botao" + indice;

        $('table tbody tr td').each(function (event) {
            if ($(this).text().trim() == telefone) {
                alert('Telefone ' + telefone + ' já está cadastrado');
                $('#Telefone').val('');
                event.preventDefault();
                return false;
            }
        })


        if (host.indexOf('http') === -1) {
            host = "http://" + host + "/Fornecedor/AdicionarTelefone"
        }

        $.ajax({
            url: host,
            type: "POST",
            data: { telefone: telefone },
            success: function () {
                $('table tbody:last').append('<tr><td id=' + indice + '>' + telefone + ' <span id="' + identificador + '" class="glyphicon glyphicon-remove botao-remover onclick=removerTelefone(this)"></span></td></tr>');
                document.getElementById(identificador).addEventListener('click', function () {
                    removerTelefone(telefone);
                    $('#'+ indice).remove();
                });
                $('#Telefone').val('');
                
            },
            error: function () {
                alert('Não foi possível adicionar o telefone.');
            }
        });
    }

    function removerTelefone(telefone) {
        let host = window.location.host;

        if (confirm('Deseja realmente excluir o telefone?')) {
            if (host.indexOf('http') === -1) {
                host = "http://" + host + "/Fornecedor/RemoverTelefone"
            }

            $.ajax({
                url: "http://" + window.location.host + "/Fornecedor/RemoverTelefone",
                type: "POST",
                data: { telefone: telefone },
                success: function (data) {
                    if (data.Removeu) {
                        alert('Telefone excluído');
                    }
                    else {
                        alert('Não foi possível excluir o registro');
                    }
                },
                error: function () {
                    alert('Ocorreu um erro e não foi possível excluir o telefone.');
                }
            });
        }
    }

    $('#CPFCNPJ').on('blur', function () {
        if ($('#CPFCNPJ').val().length == 14) {
            $('#pessoaFisica').css({ "display": "block" });
        }
    });

});



