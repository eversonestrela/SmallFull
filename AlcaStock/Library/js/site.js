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

function formatarCPF(input) {
    // Remove os caracteres não numéricos
    let cpf = input.value.replace(/\D/g, '');

    // Aplica a máscara
    cpf = cpf.replace(/^(\d{3})(\d{3})(\d{3})(\d{2})$/, '$1.$2.$3-$4');

    // Atualiza o valor do campo
    input.value = cpf;
}