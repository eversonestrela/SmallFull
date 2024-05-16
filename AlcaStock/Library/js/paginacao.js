// Função que irá montar as consultas e paginação
function configurarConsulta(tabelaId, valorConsulta, valorPesquisa, urlConsulta, metodo) {
    
    $(document).ready(function () {
        // Variáveis globais para controlar a paginação
        var registrosPorPagina = 20; // Número de registros por página
        var paginaAtual = 1; // Página atual

        // Função para atualizar a página atual e exibir registros
        function atualizarPagina(pagina) {
            paginaAtual = pagina;
            exibirRegistrosPorPagina(pagina);
            atualizarBotoesPaginacao();
        }

        // Função para ir para a primeira página
        function irParaPrimeiraPagina() {
            atualizarPagina(1);
        }

        // Função para ir para a última página
        function irParaUltimaPagina() {
            var numPaginas = Math.ceil($(tabelaId + ' tbody tr').length / registrosPorPagina);
            atualizarPagina(numPaginas);
        }

        // Função para atualizar o estado dos botões "Anterior" e "Próximo"
        function atualizarBotoesPaginacao() {
            var numPaginas = Math.ceil($(tabelaId + ' tbody tr').length / registrosPorPagina);

            // Desabilitar o botão "Anterior" se estiver na primeira página
            if (paginaAtual === 1) {
                $('#paginaAnterior').addClass('disabled');
            } else {
                $('#paginaAnterior').removeClass('disabled');
            }

            // Desabilitar o botão "Próximo" se estiver na última página
            if (paginaAtual === numPaginas) {
                $('#paginaProxima').addClass('disabled');
            } else {
                $('#paginaProxima').removeClass('disabled');
            }
        }

        // Função para exibir registros com base na página atual
        function exibirRegistrosPorPagina(pagina) {
            var startIndex = (pagina - 1) * registrosPorPagina;
            var endIndex = startIndex + registrosPorPagina;

            // Esconda todos os registros
            $(tabelaId + ' tbody tr').hide();

            // Mostre apenas os registros da página atual
            $(tabelaId + ' tbody tr').slice(startIndex, endIndex).show();

            // Remova a classe 'active' de todos os links de página
            $('.pagination li.page-item').removeClass('active');

            // Adicione a classe 'active' ao link da página atual
            $('.pagination li.page-item a.page-link:contains(' + pagina + ')').parent().addClass('active');
        }

        // Manipulador de evento para clicar em um link de página
        $('.pagination').on('click', 'a.page-link', function (e) {
            e.preventDefault();

            var paginaClicada = parseInt($(this).text());

            if (!isNaN(paginaClicada)) {
                atualizarPagina(paginaClicada);
            } else if ($(this).parent().is('#paginaAnterior')) {
                if (paginaAtual > 1) {
                    atualizarPagina(paginaAtual - 1);
                }
            } else if ($(this).parent().is('#paginaProxima')) {
                if (paginaAtual < numPaginas) {
                    atualizarPagina(paginaAtual + 1);
                }
            }
        });

        // Obtenha o valor do campo de entrada
        var consulta = $(valorConsulta).val();
        var pesquisa = $(valorPesquisa).val();

        $.ajax({
            url: urlConsulta,
            type: metodo,
            dataType: 'json',
            data: { consulta: consulta, tipoPesquisa: pesquisa }, // Adicione o valor do campo como parâmetro
            success: function (data) {

                // Mostre a div da paginação e do contador
                $('#paginacaoRegistrosDiv').show();
                $('#contadorRegistrosDiv').show();
                $('#contadorRegistros').text(data.length);

                // Remove todos os itens de página, exceto os de "Anterior" e "Próximo"
                $('.pagination li').not('#paginaAnterior, #paginaProxima').remove();

                // Calcula o número total de páginas com base no número de registros e registros por página
                var numPaginas = Math.ceil(data.length / registrosPorPagina);

                // Adiciona links de página dinamicamente
                for (var i = 1; i <= numPaginas; i++) {
                    var pageLink = $('<a>').addClass('page-link').attr('href', '#').text(i);
                    var li = $('<li>').addClass('page-item').append(pageLink);
                    $('#paginaProxima').before(li);
                }

                // Exibe os registros da página atual
                exibirRegistrosPorPagina(paginaAtual);

                // Configure os botões "Anterior" e "Próximo" para chamar as funções apropriadas
                $('#paginaAnterior').click(function () {
                    if (!$(this).hasClass('disabled')) {
                        irParaPrimeiraPagina();
                    }
                });

                $('#paginaProxima').click(function () {
                    if (!$(this).hasClass('disabled')) {
                        irParaUltimaPagina();
                    }
                });

                // Inicialize os botões de paginação no carregamento da página
                atualizarBotoesPaginacao();
            },
            error: function () {
                alert('Erro ao consultar pessoas.');
            }
        });
    });
}