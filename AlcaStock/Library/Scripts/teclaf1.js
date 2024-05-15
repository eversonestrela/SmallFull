// Captura o evento da tecla pressionada e associa à função grabKey
$(document).keydown(grabKey); // Para IE, Chrome e FF
//$(document).keypress(grabKey); // Para FF, Safari e Opera

function grabKey(event) {

    var e = (window.event) ? window.event : event; // Essecial para funcionar no IE

    if (e.keyCode == 112) { // Verifica se a tecla pressionada é F1
        if ($.browser.msie) {
            e.returnValue = false;  // Previne o comportamento padrão no IE
            e.cancelBubble = true;  // Previne o comportamento padrão no IE
            e.keyCode = 0;   // Previne o comportamento padrão no IE
            document.onhelp = new Function("return false"); // Previne a abertura do help no IE
            window.onhelp = new Function("return false"); // Previne a abertura do help no IE
            window.open('Documentacao/sisprevweb.htm', 'Ajuda', 'height=550,width=900,left=' + ((screen.width - 900) / 2) + ',status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=false');
        } else {
            e.stopPropagation(); // Previne o comportamento padrão nos browsers bons
            e.preventDefault(); // Previne o comportamento padrão nos browsers bons
            window.open('Documentacao/sisprevweb.htm', 'Ajuda', 'height=550,width=900,left=' + ((screen.width - 900) / 2) + ',status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=false');
        }
    }
}