/*
 FORMATA DOCUMENTOS CPF, CNPJ E RG
 */

function MascaraCNPJ(campo) {
    if (mascaraInteiro(campo) == false) {
        event.returnValue = false;
    }
    return formataCampo(campo, '00.000.000/0000-00', event);
}

function MascaraCPF(campo) {
    if (mascaraInteiro(campo) == false) {
        event.returnValue = false;
    }
    return formataCampo(campo, '000.000.000-00', event);
}

function MascaraRG(campo) {
    if (mascaraInteiro(campo) == false) {
        event.returnValue = false;
    }
    return formataCampo(campo, '00.000.000-0', event);
}

function mascaraInteiro() {
    if (event.keyCode < 48 || event.keyCode > 57) {
        event.returnValue = false;
        return false;
    }
    return true;
}

function formataCampo(campo, Mascara, evento) {
    var boleanoMascara;

    var Digitado = evento.keyCode;
    exp = /\-|\.|\/|\(|\)| /g
    campoSoNumeros = campo.toString().replace(exp, "");

    var posicaoCampo = 0;
    var NovoValorCampo = "";
    var TamanhoMascara = campoSoNumeros.length;;

    if (Digitado != 8) {
        for (i = 0; i <= TamanhoMascara; i++) {
            boleanoMascara = ((Mascara.charAt(i) == "-") || (Mascara.charAt(i) == ".")
                || (Mascara.charAt(i) == "/"))
            boleanoMascara = boleanoMascara || ((Mascara.charAt(i) == "(")
                || (Mascara.charAt(i) == ")") || (Mascara.charAt(i) == " "))
            if (boleanoMascara) {
                NovoValorCampo += Mascara.charAt(i);
                TamanhoMascara++;
            } else {
                NovoValorCampo += campoSoNumeros.charAt(posicaoCampo);
                posicaoCampo++;
            }
        }
        return NovoValorCampo;
    } else {
        return campo.substring(0, campo.length);
    }
}

function somenteNumeros(e) {
    var charCode = e.charCode ? e.charCode : e.keyCode;
    if (charCode != 8 && charCode != 9) {
        if (charCode < 48 || charCode > 57) {
            e.preventDefault();
            return false;
        }
    }
}