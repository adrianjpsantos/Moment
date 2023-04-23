$('input#CPF').blur(() => {
    let totalValue = $('input#CPF').val();
    if (totalValue.length <= 14) {
        $('input#CPF').mask('000.000.000-00');
        console.log(totalValue.length + " = CPF");
    } else {
        $('input#CPF').mask('00.000.000/0000-00');
        console.log(totalValue.length + " = CNPJ")
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

