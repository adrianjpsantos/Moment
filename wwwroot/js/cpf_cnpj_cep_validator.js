
$('input#CPF').mask('000.000.000-00');
$('input#CNPJ').mask('00.000.000/0000-00');

$('input#CPF').blur(()=>{  
    if(!testaCPF($('input#CPF').cleanVal())){
        $('span#CPF').text('CPF não é Válido');
    }
});

$('input#CNPJ').blur(()=>{  
    if(!validarCNPJ($('input#CNPJ').cleanVal())){
        $('span#CNPJ').text('CNPJ não é Válido');
    }
});

function testaCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF == "00000000000") return false;

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) return false;
    return true;
}

function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') return false;

    if (cnpj.length != 14)
        return false;

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;

    return true;

}

//--------------------
$('input#ZipCodeAddress').mask('00000-000');
$('input#ZipCodeAddress').blur(() => {
    let cep = $('input#ZipCodeAddress').cleanVal();
    if (cep != '') {

        $('#loading-modal').modal('show');

        $.getJSON(`https://viacep.com.br/ws/${cep}/json/?callback=?`, dados => {

            if (!('erro' in dados)) {

                setTimeout(() => {
                    $('#StreetAddress').val(dados.logradouro);
                    $('#DistrictAddress').val(dados.bairro);
                    $('#CityAddress').val(dados.localidade);
                    $('#StateAddress').val(dados.uf);
                    $('#loading-modal').modal('hide');
                }, 1000);

            }
            else {
                $('#loading-modal').modal('hide');
            }
        });
    }
    else {

        $('#StreetAddress').val('');
        $('#DistrictAddress').val('');
        $('#CityAddress').val('');
        $('#StateAddress').val('');
    }
});

