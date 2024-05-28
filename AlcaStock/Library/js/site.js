$(document).ready(function () {
    var $seuCampoCpf = $("#txtCpf");
    $seuCampoCpf.mask('000.000.000-00', { reverse: true });
});

function convertToUppercase(event) {
    var input = event.target;
    input.value = input.value.toUpperCase();
}

function maskPhone(event) {
    var input = event.target;
    var value = input.value.replace(/\D/g, ''); // Remove todos os caracteres não numéricos

    // Adiciona a máscara conforme o comprimento
    if (value.length > 10) {
        value = value.slice(0, 11); // Limita ao tamanho máximo (11 dígitos)
        value = value.replace(/^(\d{2})(\d{5})(\d{4})$/, "($1) $2-$3");
    } else if (value.length > 9) {
        value = value.slice(0, 10); // Limita ao tamanho máximo (10 dígitos)
        value = value.replace(/^(\d{2})(\d{4})(\d{4})$/, "($1) $2-$3");
    }

    input.value = value;
}
