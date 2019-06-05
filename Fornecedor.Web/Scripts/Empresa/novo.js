$(document).ready(function () {

    $('#UF').on('keyup', function () {
        let uf = $('#UF').val();

        if (uf.length > 2) {
            uf = uf.substring(0, 2);
            $('#UF').val(uf);
        }
        else {
            uf = uf.toUpperCase();
            $('#UF').val(uf);
        }
    });

    $('#CNPJ').on('keypress', function (e) {
        somenteNumeros(e);
    });

    $('#CNPJ').on('keyup', function (event) {
        let valorCampo = $('#CNPJ').val();

        if (valorCampo === undefined || valorCampo === '') {
            event.preventDefault();
            return;
        }

        let mascara = MascaraCNPJ(valorCampo);

        if (valorCampo.length <= 18) {
            $('#CNPJ').val(mascara);
        }
        else {
            $('#CNPJ').val(mascara.substring(0, 18));
        }
    });

});