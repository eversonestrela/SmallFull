var podePost = true; //variável que cancela o post no firefox

//função principal
function ClicouEnter(evt) {
    evt = getEvent(evt);
    if (getKeyCode(evt) != 13)
        return true;

    var elementAtivo = getTarget(evt);
    if (!elementAtivo)
        return true; //se não tiver nenhum elemento ativo
    if (!elementAtivo.type)
        return true; //se não tiver nenhum elemento ativo

    if (elementAtivo.type.toLowerCase() == "submit" || elementAtivo.type.toLowerCase() == "button") {
        podePost = true;
        elementAtivo.click();
        return cancelaPost(evt);
    }

    var nextElement = null;
    if (elementAtivo.tabIndex == 0)
        nextElement = getNextElementByName(elementAtivo);
    else
        nextElement = getNextElementByTabIndex(elementAtivo);

    if (nextElement) {
        var theForm = document.forms[0];
        if (theForm.addEventListener)
            theForm.addEventListener('submit', enviaForm, false); //evento submit no form para FireFox
        if (nextElement.type.toLowerCase() == "submit" || nextElement.type.toLowerCase() == "button") {
            if (elementAtivo.tabIndex == 0)
                return true;
            podePost = true;
            nextElement.click();
            return cancelaPost(evt);
        }

        podePost = false;
        nextElement.focus();

        return cancelaPost(evt);
    }
    else {
        podePost = true;
        return true;
    }
}

//Função para cancelar o envio do form para o FireFox
function enviaForm(evt) {
    if (!podePost) {
        evt.cancelBubble = true;
        evt.returnValue = false;
        if (evt.preventDefault) evt.preventDefault();
        if (evt.stopPropagation) evt.stopPropagation();
        podePost = true;
        return false;
    }
    else
        return true;
}

function cancelaPost(evt) {
    evt.cancelBubble = true;
    evt.returnValue = false;
    if (evt.preventDefault) evt.preventDefault();
    if (evt.stopPropagation) evt.stopPropagation();
    return false;
}
// recupera o evento do form
function getEvent(evt) {
    if (!evt) evt = window.event; //IE
    return evt;
}

//Recupera o elemento que está com o foco
function getTarget(evt) {
    var target;
    if (evt.srcElement)
    { target = evt.srcElement; }
    else if (evt.target)
    { target = evt.target };
    return target;
}

//Recupera o código da tecla que foi pressionado
function getKeyCode(evt) {
    var code;
    if (typeof (evt.keyCode) == 'number')
        code = evt.keyCode;
    else if (typeof (evt.which) == 'number')
        code = evt.which;
    else if (typeof (evt.charCode) == 'number')
        code = evt.charCode;
    else
        return 0;

    return code;
}

//Recupera o elemento deacordo com o TabIndex
function getElementByTabIndex(tabIndex) {
    var form = document.forms[0];
    for (var i = 0; i < form.elements.length; i++) {
        var el = form.elements[i];
        if (el.tabIndex && el.tabIndex == tabIndex) {
            return el;
        }
    }
    return null;
}

//Recupera o próximo elemento de acordo com o nome
function getNextElementByTabIndex(elementAtivo) {
    var targetTabIndex = elementAtivo.tabIndex;
    var nextTabIndex = targetTabIndex + 1;
    var nextElement = getElementByTabIndex(nextTabIndex);

    //margem de erro
    var i = 0;
    for (i = 0; i < 15; i++)//tolerância de tabIndex
    {
        if (nextElement != null && !nextElement.disabled) {
            break;
        }
        nextTabIndex = nextTabIndex + 1;
        nextElement = getElementByTabIndex(nextTabIndex);
    }
    return nextElement;
}

//Recupera o próximo elemento de acordo com o nome
function getNextElementByName(elementAtivo) {
    var passou = false;
    var form = document.forms[0];
    for (var i = 0; i < form.elements.length; i++) {
        var el = form.elements[i];
        if (el && el.id == elementAtivo.id || passou) {
            passou = true;
            //encontrou o elemento atual
            var x = i + 1;
            var elnx = form.elements[x];

            if (elnx) {
                switch (elnx.type) {
                    case "text":
                    case "submit":
                    case "button":
                    case "reset":
                    case "select-one":
                    case "checkbox":
                    case "image":
                    case "password":
                    case "radio":
                    case "reset":
                    case "submit":
                    case "textarea":
                        if (elnx.disabled)
                            continue;
                        break;
                    default:
                        continue;
                        break;
                }
                return elnx;
            }
        }
    }
    return null;
}