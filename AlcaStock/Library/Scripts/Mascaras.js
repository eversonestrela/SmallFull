//Biblioteca Geral de Scripts

//********************************************************************************************
// Constantes para validação de campos.
var reUmOuMaisDigitos = /[\d+]/;
var reNaoDigitos = /[^\d]/gi;
//********************************************************************************************


//BIBLIOTECA PARA REALIZAR O FILTER NO CONTROLE: DROPDOWNLIST
// 
// INICIO
//
function Filter(combo)
{
	if(combo!=null){
		var arrItens = combo.options;
		if(arrItens!=null && event.srcElement.id==combo.id)
		{
			combo.selectedIndex = (combo.Posicao=="0") ? 0 : combo.Posicao;
			
			var filtro = GetFilter(combo);
			
			TooltipFilter(combo, filtro);
			SetTextCombo(combo, filtro);				
		}
	}
}

//Esta função marca o item selecionado inicialmente no dropdownlist
function SetValueInitial(combo)
{
	try{
		combo.OldSelectedIndex = combo.selectedIndex;
	}
	catch(ex){}
}

function SetTextCombo(combo, filtro)
{
	combo.OldFiltro = filtro;
	for(var i=0; i<combo.options.length; i++){
		if(combo.options[i].text.substring(0, filtro.length).toLowerCase()==filtro.toLowerCase()){
			combo.Filtro = filtro;
			combo.options[i].selected = true;
			combo.selectedIndex = i;
			combo.Posicao = i;
			break;	
		}
	}
}

function GetFilter(combo)
{
	var filtro = "";
	
	if(combo!=null){
		filtro = (combo.Filtro!="0") ? combo.Filtro : "";
		var codeKey = (event.which) ? event.which : event.keyCode;

		filtro += String.fromCharCode(codeKey);
	}
	
	return filtro;
}

function RemoveFilter(combo)
{
	if(combo!=null){
		var codeKey = (event.which) ? event.which : event.keyCode;
		
		if(codeKey!=8 && codeKey!=32)
			return;
			
		var arrItens = combo.options;
		if(arrItens!=null && event.srcElement.id==combo.id){
			combo.selectedIndex = (combo.Posicao=="0") ? 0 : combo.Posicao;
			
			var filtro = "";
			

			if(codeKey==8){
				filtro = (combo.Filtro!=combo.OldFiltro) ? combo.Filtro : combo.OldFiltro.substring(0, combo.OldFiltro.length-1);
				event.returnValue = false;
			}
			else if(codeKey==32){
				filtro = ((combo.Filtro!="0") ? combo.Filtro : "") + " ";
			}
			
			TooltipFilter(combo, filtro);
			SetTextCombo(combo, filtro);				
		}
	}
}

function TooltipFilter(control, msg)
{
	var name = control.id+"_divTooltip";
	var element = document.getElementById(name);

	if(element==null)
		element = GetControlTooltip(control);
	
	element.innerText = msg;		
}

function GetControlTooltip(control, evt)
{
	var name = control.id+"_divTooltip";
	var display = document.createElement("div");
	display.id = name;
	
	var css = "BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; BORDER-TOP: black 1px solid; ";
	css += " FONT-SIZE: 9pt; FONT-FAMILY: arial; Z-INDEX: 1000;";
	css += " POSITION: absolute; BACKGROUND-COLOR: cornsilk; ms_positioning='FlowLayout'; HEIGHT: 20px";
	
	display.style.cssText = css;
	SetPositionControl(control, display);
	
	document.body.appendChild(display);
	return display;
}

function removeElement(control) {
	if(control!=null){
		var name = control.id+"_divTooltip";
		var elem = document.getElementById(name);
		if(elem!=null)
			document.body.removeChild(elem);
	}
}

function removeElementByID(id, execClearTimeout) {
	if(id!=null){
		var name = id+"_divTooltip";
		var elem = document.getElementById(name);
		if(elem!=null){ document.body.removeChild(elem); }
		
		elem = document.getElementById(id);
		if(elem!=null && elem.onfocus==null && elem.isTextEdit==false){elem.value = ""; }
	}
	
	if(execClearTimeout!=null && (execClearTimeout=="true" || execClearTimeout==true))
		clearTimeout("removeElementByID");
}


function executeEventOnChange(control)
{
	if(control!=null && control.onchange!=null){
		try{
			if(control.OldSelectedIndex != control.selectedIndex){
				control.OldSelectedIndex = control.selectedIndex;
				control.onchange(); 
				disabledOnChangeElements();
			}
		}
		catch(ex){}
	}
}

function disabledOnChangeElements()
{
	for(i=0; i<document.forms[0].elements.length; i++){
		var control = document.forms[0].elements[i];
		if(control!=null){
			control.onchange = null;
		}
	}
}

function SetPositionControl(control, display)
{
	var cElement = control;
	var useClient = (cElement.offsetTop == 0) ? ((cElement.offsetParent.tagName == "TR") ? false : true) : false;
    	
	if (useClient) {
	var	 x = cElement.clientLeft;
	var	 y = cElement.clientTop;
	} 
	else {
	var	 x = cElement.offsetLeft;
	var	 y = cElement.offsetTop;
	}
	
	var pElement = cElement.offsetParent;
	
	while (pElement != document.body) {
		if (useClient) {
			x += pElement.clientLeft;
			y += pElement.clientTop;
		} 
		else {
			x += pElement.offsetLeft;
			y += pElement.offsetTop;
		}
		pElement = pElement.offsetParent;
	}
	display.style.pixelLeft = x;
	display.style.pixelTop = (y - 20);
}

//
// FIM
// 
// BIBLIOTECA PARA REALIZAR O FILTER NO CONTROLE: DROPDOWNLIST




//Mascara de digitacao de Data
function Data(Campo, teclapres) 
{
	var tecla = teclapres.keyCode;
	var vr = new String(Campo.value);
	vr = vr.replace("/", "");
	vr = vr.replace("/", "");
	tam = vr.length + 1;
	if (tecla != 9 && tecla != 8)
	{
		if (tam > 2 && tam < 4)
			Campo.value = vr.substr(0, 2)+'/'+vr.substr(2, tam);
		if (tam >= 5 && tam < 6)
			Campo.value = vr.substr(0, 2)+'/'+vr.substr(2, 4)+'/'+vr.substr(6, tam);
	}
}

function mascara_CEP()
{
	// Caso seja pressionada a tecla delete ou backspace
	// não executa-se a máscara
    if ((event.keyCode == 8) || (event.keyCode == 46))
		return true;
	// -> Obtem o Valor do Objeto chamador do evento
    var aux = event.srcElement.value;
    if ((aux.length == 5))
    {
		aux = aux + '-';
        event.srcElement.value = aux;
    }
return aux;
}

function mascara_Data()
{
	// Caso seja pressionada a tecla delete ou backspace
	// não executa-se a máscara
    if ((event.keyCode == 8) || (event.keyCode == 46))
		return true;
	// -> Obtem o Valor do Objeto chamador do evento
    var aux = event.srcElement.value;
    if(aux.length != null)
    {
        if ((aux.length == 2) || (aux.length == 5))
        {
		    aux = aux + '/';
            event.srcElement.value = aux;
        }
    }
    
return aux;
}

//Retorna o objeto XMLHTTP utilizado em chamadas AJAX
function getHTTPObject()
{
	var xmlhttp;
	try
	{
		xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
	}
	catch(e)
	{
		try
		{
			xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
		}
		catch(E)
		{
			xmlhttp = false;
		}
	}
	if (!xmlhttp && typeof XMLHttpRequest != 'undefined')
	{
		try
		{
			xmlhttp = new XMLHttpRequest();
		}
		catch(e)
		{
			xmlhttp = false;
		}
	}
	return xmlhttp;
}


// Método que verifica se o campo CPF esta vazio, e invoca o método que valida o CPF
function ExitCPF()
{
	var aux = event.srcElement.value;
	if (aux != "")
	{
		return validacpf2()
	}
}

//Método que cria a máscara do CPF
function mascara_cpf2()
{
  	var mycpf2 = event.srcElement.value;
    if (mycpf2.length == 3) {
        mycpf2 = mycpf2 + '.';
        event.srcElement.value = mycpf2;
    }
    if (mycpf2.length == 7) {
        mycpf2 = mycpf2 + '.';
        event.srcElement.value = mycpf2;
    }
    if (mycpf2.length == 11) {
        mycpf2 = mycpf2 + '-';
        event.srcElement.value = mycpf2;
    }
    
    return mycpf2;
}

//Método que valida o CPF
function validacpf2()
{ 
	var text2 = event.srcElement.value;
	if(text2 != "")
	{	
		if (text2.length == 14) 
		{
        text2 = text2.replace(".", "");
        text2 = text2.replace(".", "");
        text2 = text2.replace("-", "");  
        
		}

		var i; 
		s = text2;
		var c = s.substr(0,9); 
		var dv = s.substr(9,2); 
		var d1 = 0; 
			for (i = 0; i < 9; i++) 
			{ 
			d1 += c.charAt(i)*(10-i); 
			} 
		  
		if (d1 == 0){ 
		alert("CPF Invalido"); 
		event.srcElement.value = "";
		return false;
		} 
		  
		d1 = 11 - (d1 % 11); 
		if (d1 > 9) d1 = 0; 
			if (dv.charAt(0) != d1) 
			{ 
			alert("CPF Invalido"); 
			event.srcElement.value = "";
			return false; 
			} 
		  
		d1 *= 2; 
			for (i = 0; i < 9; i++) 
			{ 
			d1 += c.charAt(i)*(11-i); 
			} 

		d1 = 11 - (d1 % 11); 
		if (d1 > 9) d1 = 0; 
			if (dv.charAt(1) != d1) 
			{ 
			alert("CPF Invalido");
			event.srcElement.value = ""; 
			return false; 
			} 
	return true;
	}

}

//********************************************************************************************
function formataCpf(campo, teclapres){
	var tecla = teclapres.keyCode;
	var vr = campo.value;
    var key = cleanKeyCode(tecla);
    
    if (teclaAceita(tecla, false))        
        return true;
        
    if (tecla != 0)    
        if (tecla != 8)    
            if (! reUmOuMaisDigitos.test(key))
                return false;
	   
	if (tecla != 0)     	    
        if (tecla != 8)
            if (travaCampo(vr, 18))
                return false;
	    
    vr = vr.replace(reNaoDigitos, '');			
	tam = vr.length + 1;
		
	if (tam == 13)
        campo.value = vr.substr(0,3) + '.' + vr.substr(3,3) + '.' + vr.substr(6,3) + '-' + vr.substr(9,tam-8);        
        
        if (tam <= 12)
        {
            if (tam > 3 && tam < 7)
	            campo.value = vr.substr(0, 3) + '.' + vr.substr(3, tam);
            if (tam >= 7 && tam <10)
	            campo.value = vr.substr(0,3) + '.' + vr.substr(3,3) + '.' + vr.substr(6,tam-6);
            if (tam >= 10 && tam <= 12)
	            campo.value = vr.substr(0,3) + '.' + vr.substr(3,3) + '.' + vr.substr(6,3) + '-' + vr.substr(9,tam-9);
        }
}

//********************************************************************************************
function formataCnpj(campo, teclapres){
	var tecla = teclapres.keyCode;
	var vr = campo.value;
    var key = cleanKeyCode(tecla);
    
    if (teclaAceita(tecla, false))        
        return true;
        
    if (tecla != 8)    
        if (! reUmOuMaisDigitos.test(key))
            return false;
	    	    
    if (tecla != 8)
        if (travaCampo(vr, 18))
            return false;
	    
    vr = vr.replace(reNaoDigitos, '');			
	tam = vr.length + 1;
	
	if (tecla != 8)
    {
        if (tam > 2 && tam < 6)
            campo.value = vr.substr(0, 2) + '.' + vr.substr(2, tam);
        if (tam >= 6 && tam < 9)
            campo.value = vr.substr(0,2) + '.' + vr.substr(2,3) + '.' + vr.substr(5,tam-5);
        if (tam >= 9 && tam < 13)
            campo.value = vr.substr(0,2) + '.' + vr.substr(2,3) + '.' + vr.substr(5,3) + '/' + vr.substr(8,tam-8);
        if (tam >= 13 && tam < 15)
            campo.value = vr.substr(0,2) + '.' + vr.substr(2,3) + '.' + vr.substr(5,3) + '/' + vr.substr(8,4)+ '-' + vr.substr(12,tam-12);
    }
}

//********************************************************************************************
function saidaCpfCnpj(campo, displayMsg, travaFoco, tipoMsg)
{
	var tam = campo.value.length;
	
	if( campo.value != '' )
	{
	    if ((tam != 14) && (tam != 18))
	    {
	        if (displayMsg)
	        {
	            if(tipoMsg == 'cpf')
	            {
	                alert('O CPF informado não contém o número de dígitos corretos.');
	            }
	            else
	            {
	                alert('O CNPJ informado não contém o número de dígitos corretos.');
	            }
	        }
    	            
	        if (travaFoco)
	            campo.focus();
    	    
	        campo.value = '';
	    }
	}
}

function teclaAceita(keyCode, validaBackSpace)
{
//        return (keyCode == 13 || keyCode == 8 || keyCode == 9 || keyCode == 46 || ((keyCode > 37) && (keyCode < 41)) )
    if (validaBackSpace)
        return (keyCode == 13 || keyCode == 8 || keyCode == 9)
    else
        return (keyCode == 13 || keyCode == 9)
//        return (keyCode == 13 || keyCode == 9 || keyCode == 46 || ((keyCode > 37) && (keyCode < 41)))
}

//********************************************************************************************
function travaCampo(texto, tamMax)
{
    if (texto.length < tamMax)
        return false;
    else
        return true;
}

function cleanKeyCode(key)
{
//    switch(key)
//    {
//	    case 96: return "0"; break;
//	    case 97: return "1"; break;
//	    case 98: return "2"; break;
//	    case 99: return "3"; break;
//	    case 100: return "4"; break;
//	    case 101: return "5"; break;
//	    case 102: return "6"; break;
//	    case 103: return "7"; break;
//	    case 104: return "8"; break;
//	    case 105: return "9"; break;
//	    default: return String.fromCharCode(key); break;
//    }
return String.fromCharCode(key);
}


function Limpar(valor, validos) 
    {
        // retira caracteres invalidos da string
        var result = "";
        var aux;
        for (var i=0; i < valor.length; i++) 
        {
            aux = validos.indexOf(valor.substring(i, i+1));
            if (aux>=0) 
            {
                result += aux;
            }
        }
        return result;
    }
    
    function FormataMoney(campo,tammax,teclapres,decimal) 
    {
        var tecla = teclapres.keyCode;
        vr = Limpar(campo.value,"0123456789");
        tam = vr.length;
        dec=decimal

        if (tam < tammax && tecla != 8)
        { 
            tam = vr.length + 1 ; 
        }

        if (tecla == 8 )
        { 
            tam = tam - 1 ; 
        }

        if ( tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105 )
        {

            if ( tam <= dec )
            { 
                campo.value = vr ; 
            }

            if ( (tam > dec) && (tam <= 5) )
            {
                campo.value = vr.substr( 0, tam - 2 ) + "," + vr.substr( tam - dec, tam ) ; 
            }
            if ( (tam >= 6) && (tam <= 8) )
            {
                campo.value = vr.substr( 0, tam - 5 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - dec, tam ) ; 
            }
            if ( (tam >= 9) && (tam <= 11) )
            {
                campo.value = vr.substr( 0, tam - 8 ) + "." + vr.substr( tam - 8, 3 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - dec, tam ) ; 
            }
            if ( (tam >= 12) && (tam <= 14) )
            {
                campo.value = vr.substr( 0, tam - 11 ) + "." + vr.substr( tam - 11, 3 ) + "." + vr.substr( tam - 8, 3 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - dec, tam ) ; 
            }
            if ( (tam >= 15) && (tam <= 17) )
            {
                campo.value = vr.substr( 0, tam - 14 ) + "." + vr.substr( tam - 14, 3 ) + "." + vr.substr( tam - 11, 3 ) + "." + vr.substr( tam - 8, 3 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - 2, tam ) ;
            }
        } 
        
        
    }
    
    
    
function validaCNPJ() {
    CNPJ = document.validacao.CNPJID.value;
    erro = new String;
    if (CNPJ.length < 18) erro += "E' necessarios preencher corretamente o numero do CNPJ! \n\n";
    if ((CNPJ.charAt(2) != ".") || (CNPJ.charAt(6) != ".") || (CNPJ.charAt(10) != "/") || (CNPJ.charAt(15) != "-")){
        if (erro.length == 0) erro += "E' necessarios preencher corretamente o numero do CNPJ! \n\n";
    }
    //substituir os caracteres que nao sao numeros
    if(document.layers && parseInt(navigator.appVersion) == 4){
        x = CNPJ.substring(0,2);
        x += CNPJ.substring(3,6);
        x += CNPJ.substring(7,10);
        x += CNPJ.substring(11,15);
        x += CNPJ.substring(16,18);
        CNPJ = x;
    } else {
        CNPJ = CNPJ.replace(".","");
        CNPJ = CNPJ.replace(".","");
        CNPJ = CNPJ.replace("-","");
        CNPJ = CNPJ.replace("/","");
    }
    var nonNumbers = /\D/;
    if (nonNumbers.test(CNPJ)) erro += "A verificacao de CNPJ suporta apenas numeros! \n\n";
    var a = [];
    var b = new Number;
    var c = [6,5,4,3,2,9,8,7,6,5,4,3,2];
    for (i=0; i<12; i++){
    a[i] = CNPJ.charAt(i);
    b += a[i] * c[i+1];
    }
    if ((x = b % 11) < 2) { a[12] = 0 } else { a[12] = 11-x }
    b = 0;
    for (y=0; y<13; y++) {
    b += (a[y] * c[y]);
    }
    if ((x = b % 11) < 2) { a[13] = 0; } else { a[13] = 11-x; }
    if ((CNPJ.charAt(12) != a[12]) || (CNPJ.charAt(13) != a[13])){
    erro +="Digito verificador com problema!";
    }
    if (erro.length > 0){
    alert(erro);
    return false;
    } else {
    alert("CNPJ valido!");
    }
    return true;
}

function StrZeroVirgula(campo, casas) {
    vr = campo.value;
    ar = vr.split(",");

    num = ar[0] || "0";
    dec = ar[1] || "";
    len = dec.length;
    
    for (i = 0; i < casas-len; i++) {
        dec = dec + "0";
    }
    
    campo.value = num + "," + dec;
}

//Formata número tipo moeda usando o evento onKeyDown
function Formata(campo, tammax, teclapres, decimal) {
    var tecla = teclapres.keyCode;
    vr = Limpar(campo.value, "0123456789");
    tam = vr.length;
    dec = decimal

    if (tam < tammax && tecla != 8) { tam = vr.length + 1; }

    if (tecla == 8)
    { tam = tam - 1; }

    if (tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105) {
        if ((tam > dec) && (tam <= (dec+3))) {
            campo.value = vr.substr(0, tam - dec) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= (dec + 4)) && (tam <= (dec + 6))) {
            campo.value = vr.substr(0, tam - (dec + 3)) + "." + vr.substr(tam - (dec + 3), 3) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= (dec + 7)) && (tam <= (dec + 9))) {
            campo.value = vr.substr(0, tam - (dec + 6)) + "." + vr.substr(tam - (dec + 6), 3) + "." + vr.substr(tam - (dec + 3), 3) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= (dec + 10)) && (tam <= (dec + 12))) {
            campo.value = vr.substr(0, tam - (dec + 9)) + "." + vr.substr(tam - (dec + 9), 3) + "." + vr.substr(tam - (dec + 6), 3) + "." + vr.substr(tam - (dec + 3), 3) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= (dec + 13)) && (tam <= (dec + 15))) {
            campo.value = vr.substr(0, tam - (dec + 12)) + "." + vr.substr(tam - (dec + 11), 3) + "." + vr.substr(tam - (dec + 9), 3) + "." + vr.substr(tam - (dec + 6), 3) + "." + vr.substr(tam - (dec + 3), 3) + "," + vr.substr(tam - dec, tam);
        }
    }
}



function BlockKeybord() {
    if (window.event) // IE
    {
        if ((event.keyCode < 48) || (event.keyCode > 57)) {
            event.returnValue = false;
        }
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        if ((event.which < 48) || (event.which > 57)) {
            event.returnValue = false;
        }
    }


}

function troca(str, strsai, strentra) {
    while (str.indexOf(strsai) > -1) {
        str = str.replace(strsai, strentra);
    }
    return str;
}

function FormataMoeda(campo, tammax, teclapres, caracter) {
    if (teclapres == null || teclapres == "undefined") {
        var tecla = -1;
    }
    else {
        var tecla = teclapres.keyCode;
    }

    if (caracter == null || caracter == "undefined") {
        caracter = ".";
    }

    vr = campo.value;
    if (caracter != "") {
        vr = troca(vr, caracter, "");
    }
    vr = troca(vr, "/", "");
    vr = troca(vr, ",", "");
    vr = troca(vr, ".", "");

    tam = vr.length;
    if (tecla > 0) {
        if (tam < tammax && tecla != 8) {
            tam = vr.length + 1;
        }

        if (tecla == 8) {
            tam = tam - 1;
        }
    }
    if (tecla == -1 || tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105) {
        if (tam <= 2) {
            campo.value = vr;
        }
        if ((tam > 2) && (tam <= 5)) {
            campo.value = vr.substr(0, tam - 2) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 6) && (tam <= 8)) {
            campo.value = vr.substr(0, tam - 5) + caracter + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 9) && (tam <= 11)) {
            campo.value = vr.substr(0, tam - 8) + caracter + vr.substr(tam - 8, 3) + caracter + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 12) && (tam <= 14)) {
            campo.value = vr.substr(0, tam - 11) + caracter + vr.substr(tam - 11, 3) + caracter + vr.substr(tam - 8, 3) + caracter + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 15) && (tam <= 17)) {
            campo.value = vr.substr(0, tam - 14) + caracter + vr.substr(tam - 14, 3) + caracter + vr.substr(tam - 11, 3) + caracter + vr.substr(tam - 8, 3) + caracter + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
    }
}

function maskKeyPress(objEvent) {
    var iKeyCode;

    if (window.event) // IE
    {
        iKeyCode = objEvent.keyCode;
        if (iKeyCode >= 48 && iKeyCode <= 57) return true;
        return false;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        iKeyCode = objEvent.which;
        if (iKeyCode >= 48 && iKeyCode <= 57) return true;
        return false;
    }


}



/**
* Generic
*/

var defaultFocusOccur;
var defaultFocusField;

function selectValue(url) {
    var interrogacao = url.indexOf('?');
    var sessionid = document.cookie.substring(document.cookie.indexOf('=') + 1);

    if (interrogacao >= 0) {
        url = url.substring(0, interrogacao) + ';jsessionid=' + sessionid + url.substring(interrogacao);
    }
    else {
        url = url + ';jsessionid=' + sessionid;
    }
    var hWnd = window.open(url, "PopUp", "width=250,height=325,resizable=yes,scrollbars=yes");
    if ((document.window != null) && (!hWnd.opener))
        hWnd.opener = document.window;
}

function updateField(field, value) {
    field.value = value;
    window.close();
}

function isDigit(str) {
    for (var i = 0; i < str.length; i++) {
        var charCode = str.charCodeAt(i);
        if (!(charCode >= 48 && charCode <= 57))
            return (false);
    }
    return (true);
}

function isLetter(str) {
    for (var i = 0; i < str.length; i++) {
        var charCode = str.charCodeAt(i);
        if (!(charCode >= 65 && charCode <= 90 || charCode >= 97 && charCode <= 122))
            return (false);
    }
    return (true);
}

function isLetterOrDigit(str) {
    for (var i = 0; i < str.length; i++) {
        var character = str.charAt(i);
        if (!isDigit(character) && !isLetter(character))
            return (false);
    }
    return (true);
}


function searchKey(campo, keyEvent) {
    var key = keyEvent.keyCode;
    document.form[campo].value = key;
}

function nextFocus(field, size, event) {
    /* Tenta recuperar a tecla pelo Netscape */
    var key = event.keyCode;
    /* ou pelo IE */
    if (key == null)
        key = event.which;
    /* Se n?o conseguir por nenhum dos dois, seta como A */
    if (key == null)
        key = 65;

    var i;
    var value = field.value;
    var selected = false;

    if (field.form.elements.length != 0 &&
      size <= value.length &&
      key != 0 && key != 8 && key != 9 && key != 16 && key != 20 && key != 27 &&
      !(key >= 33 && key <= 46) &&
      !(key >= 16 && key <= 18) &&
      !(key >= 90 && key <= 93) &&
      !(key >= 112 && key <= 123) &&
      !(key >= 144 && key <= 145))
        for (i = 0; i < field.form.elements.length - 1 && !selected; i++)
        if (field == field.form[i])
        for (j = i + 1; j < field.form.elements.length && !selected; j++)
        if (field.form[j].type != "hidden") {
        field.form[j].focus();
        selected = true
    }

}

function getField(c) {
    var i;
    var j;
    for (i = 0; i < document.forms.length; i++) {
        var f = document.forms[i];
        for (j = 0; j < f.elements.length; j++) {
            var campo = f[j];
            if (c == campo.name)
                return campo;
        }
    }
    return null;
}

function setFocus(campofoco) {
    var campo = getField(campofoco)
    if (campo != null)
        campo.focus();
}

function setFirstFieldFocus() {
    if (defaultFocusOccur != null)
        window.location.hash = defaultFocusOccur;
    if (defaultFocusField != null)
        setFocus(defaultFocusField);
    else {
        var form = document.forms[0];
        if (form != null)
            for (var i = 0; i < form.elements.length; ++i)
            if (form[i].type != 'hidden') {
            form[i].focus();
            break;
        }
    }
}

function selectAll(newState) {
    for (var i = 0; i < document.forms[0].elements.length; i++)
        document.forms[0].elements[i].checked = newState;
}

function getQueryString() {
    var res = "";
    for (var i = 0; i < document.forms[0].elements.length; i++) {
        var field = document.forms[0].elements[i];
        if (i > 0)
            res = res + "&";
        res = res + field.name + "=" + field.value;
    }
    return res;
}

function getQueryStringWithout(e) {
    var res = "";
    for (var i = 0; i < document.forms[0].elements.length; i++) {
        var elem = document.forms[0].elements[i];
        if (e != elem.name) {
            if (i > 0)
                res = res + "&";
            res = res + elem.name + "=" + elem.value;
        }
    }
    return res;
}

function getQueryStringWithoutSubmits() {
    var res = "";
    for (var i = 0; i < document.forms[0].elements.length; i++) {
        var elem = document.forms[0].elements[i];
        if (elem.type != "submit") {
            if (i > 0)
                res = res + "&";
            res = res + elem.name + "=" + elem.value;
        }
    }
    return res;
}

function getWindowName() {
    return window.name.length > 0 ? window.name : "_top";
}

/**
* Format
*/

// Constantes
SYMBOL = 0;
CARACTER = 1;
SEPARATOR = 2;
SIGNAL = 3;
UPPER = 4;
LOWER = 5;
MINUS = 6;
OTHER = 7;

function fillLeft(str, c, len) {
    for (var i = str.length; i < len; ++i)
        str = c + str;
    return (str);
}

function sizeMask(mask) {
    var caracter;
    var lenMask = 0;
    var type;
    for (var i = 0; i < mask.length; ++i) {
        caracter = mask.charAt(i);
        type = findSymbol(caracter);
        if (type != UPPER &&
        type != LOWER &&
        type != SIGNAL &&
        type != MINUS &&
        type != SEPARATOR)
            ++lenMask;
    }
    return (lenMask);
}

function findSymbol(symbol) {
    var typeSymbol = SYMBOL;
    switch (symbol) {
        case '#':
        case '0':
        case 'L':
        case 'l':
        case 'A':
        case 'a':
        case 'C':
        case 'c': 
            {
                typeSymbol = CARACTER;
                break;
            }
        case 'S': 
            {
                typeSymbol = SIGNAL;
                break;
            }
        case 's': 
            {
                typeSymbol = MINUS;
                break;
            }
        case '>': 
            {
                typeSymbol = UPPER;
                break;
            }
        case '<': 
            {
                typeSymbol = LOWER;
                break;
            }
        case '\\': 
            {
                typeSymbol = SEPARATOR;
                break;
            }
        default: typeSymbol = OTHER;
    }
    return (typeSymbol);
}

/**
* Number
*/

function validateCaracterNumber(str) {
    var caracterStr;
    for (var j = 0; j < str.length; ++j) {
        caracterStr = str.charAt(j);
        var charCode = str.charCodeAt(j);
        //caracter num?rico
        if (!isDigit(caracterStr) &&
        caracterStr != '+' &&
        caracterStr != '-')
            return (false);
    } //for
    return (true)
}

function numberZeros(displayMask) {
    var number = 0;
    for (var i = 0; i < displayMask.length; ++i)
        if (displayMask.charAt(i) == '0')
        ++number;
    return (number);
}

function insertZeros(value, displayMask) {
    var number = numberZeros(displayMask);
    if ((number > 0) &&
      (value.length != 0))
        value = fillLeft(deleteZerosLeft(value), '0', number);
    return (value);
}

function deleteZerosLeft(value) {
    var result = "";
    var i;
    for (i = 0; i < value.length; i++) {
        var caracter = value.charAt(i);
        if (caracter != '0') {
            if (isDigit(caracter))
                break;
            result = result + caracter;
        }
    }
    result = result + value.substring(i, value.length);
    if (result.length == 0 && value.indexOf("0") != -1)
        result = "0";
    return (result);
}

function deleteMaskNumber(value) {
    var caracterValue;
    var valueDelete = "";
    for (var j = 0; j < value.length; ++j) {
        caracterValue = value.charAt(j);
        if (isDigit(caracterValue))
            valueDelete = valueDelete + caracterValue;
    }
    return (valueDelete);
}

function formatNumber(value, displayMask) {
    //Verifica se o valor tem sinal e qual ? o sinal
    //CHAMADO 55446
    //var sinal = "+";
    var sinal = "";
    var sinalMinus = "";
    //  if( value.indexOf( "-" ) != -1 )
    if (lastSignal(value).indexOf("-") > -1) {
        sinal = "-";
        sinalMinus = "-";
    }
    //Exclui s?mbolos do campo
    value = deleteMaskNumber(value);
    var formatValue = "";
    var caracter;
    var symbol;
    var anterior;
    //Coloca zeros no in?cio da string
    value = insertZeros(value, displayMask);
    var lenValue = value.length - 1;
    //Percorre a m?scara da direita para a esquerda
    for (var i = displayMask.length - 1; i > -1; --i) {
        caracter = displayMask.charAt(i);
        //Se j? estiver ap?s a primeira posi??o
        if (i > 0) {
            //Verifica se o anterior ? um separador,
            //incluindo o caracter atual como s?mbolo do valor.
            anterior = findSymbol(displayMask.substring(i - 1, i));
            if (anterior == SEPARATOR) {
                formatValue = caracter + formatValue;
                --i;
            }
        }
        if (lenValue > -1) {
            symbol = findSymbol(caracter);
            if (symbol == CARACTER) {
                formatValue = value.substring(lenValue, lenValue + 1) + formatValue;
                --lenValue;
            }
            else
                if (symbol == SIGNAL)
                formatValue = sinal + formatValue;
            else
                if (symbol == MINUS)
                formatValue = sinalMinus + formatValue;
            else
                formatValue = caracter + formatValue;
        }
        else
            break;
    }
    if (hasMinusSignal(displayMask) && formatValue.indexOf("-") == -1)
        formatValue = sinalMinus + formatValue;
    else
        if (hasSignal(displayMask) && formatValue.indexOf("+") == -1 && formatValue.indexOf("-") == -1)
        formatValue = sinal + formatValue;
    //CHAMADO 55446
    //return (formatValue);
    return (sinal + formatValue);
}

//Conta quantos y a m?scara possui.
function getYearSize(displayMask) {
    var ret = 0;
    for (var i = 0; i < displayMask.length; i++) {
        if (displayMask.charAt(i) == 'y') {
            ret++;
        }
    }
    return ret;
}

//dd - dia
//mm - m?s
//yy, yyyy - ano
function formatDate(value, displayMask) {
    //Exclui simbolos do campo
    value = deleteMaskNumber(value);
    displayMask = displayMask.toLowerCase();
    var v = 0;
    var ano = '';
    var mes = '';
    var dia = '';
    var formated = '';
    var yearSize = getYearSize(displayMask);
    var c = '';
    var d = '';
    for (var i = 0; i < displayMask.length; i++) {
        c = displayMask.charAt(i);
        d = value.charAt(v);
        if (c == 'y') {
            ano += d;
            formated += d;
            v++;
            if (ano.length == yearSize) {
            }
        } else if (c == 'm') {
            mes += d;
            formated += d;
            v++;
            if (mes.length == 2) {
                var mes_i = parseInt(mes);
                if (!(1 <= mes && mes <= 12)) {
                    formated = formated.substring(0, formated.length - 2);
                }
            }
        } if (c == 'd') {
            dia += d;
            formated += d;
            v++;
            if (dia.length == 2) {
                var dia_i = parseInt(dia);
                if (!(1 <= dia && dia <= 31)) {
                    formated = formated.substring(0, formated.length - 2);
                }
            }
        } else if (c == '/' && v < value.length) {
            formated += c;
        }
    }
    return formated;
}

function lastSignal(value) {
    var iPlus = value.lastIndexOf("+");
    var iMinus = value.lastIndexOf("-");
    if ((iPlus == -1 && iMinus == -1) ||
      iPlus > iMinus)
        return "+";
    return "-";
}

function hasSignal(mask) {
    return (mask.indexOf("S") > -1 || mask.indexOf("s") > -1)
}

function hasMinusSignal(mask) {
    return (mask.indexOf("s") > -1)
}

function formatValueNumber(field, displayMask, event) {
    /* Tenta recuperar a tecla pelo Netscape */
    var key = event.keyCode;
    /* ou pelo IE */
    if (key == null)
        key = event.which;
    if (key != 9) {
        var value = field.value;
        var valueFormated = formatNumber(value, displayMask);
        if (value != valueFormated)
            field.value = valueFormated;
    }
}
/**
* String
*/

function positionMaskString(offs, displayMask) {
    var pos = 0;
    var i = 0;
    var tipo = 1;
    var ultimoTipo;
    var caracter = " ";

    while (i < displayMask.length) {
        //caracter da m?scara
        caracter = displayMask.charAt(i);
        ultimoTipo = tipo;
        tipo = findSymbol(caracter);
        if (pos >= offs &&
         tipo == CARACTER &&
         ultimoTipo != SEPARATOR)
            break;
        if (tipo != SEPARATOR &&
         tipo != LOWER &&
         tipo != UPPER)
            ++pos;
        ++i;
    }
    return (caracter);
}

function validateCaracterString(str, offs, displayMask) {
    var caracterMask;
    var caracterStr;
    var charCode;
    for (var j = 0; j < str.length; ++j) {
        caracterMask = positionMaskString(offs + j, displayMask);
        caracterStr = str.charAt(j);
        charCode = str.charCodeAt(j);
        switch (caracterMask) {
            case '#':
            case '9': 
                { //caracter num?rico ou espa?o
                    if (!(isDigit(caracterStr) || caracterStr == ' '))
                        return (false);
                    break;
                }
            case '0': 
                { //caracter num?rico
                    if (!isDigit(caracterStr))
                        return (false);
                    break;
                }
            case 'A':
            case 'a': 
                { //caracter alfanum?rico
                    if (!(isLetterOrDigit(caracterStr) || caracterStr == ' '))
                        return (false);
                    break;
                }
            case 'L':
            case 'l': 
                { //caracter alfab?tico
                    if (!(isLetter(caracterStr) || caracterStr == ' '))
                        return (false);
                    break;
                }
            case 'C':
            case 'c': break;
            case 'S': 
                {
                    if (caracterStr != '+' &&
                      caracterStr != '-')
                        return (false);
                    break;
                }
            case '\\':
            default: return (false);
        }
    }
    return (true);
}

function deleteMaskString(value, displayMask) {
    var caracter = "";
    var valueDelete = "";
    var valor = 0;
    var lenValue = 0;
    var caracterValue = "";
    var i = 0;

    while (i < displayMask.length && lenValue < value.length) {
        caracter = displayMask.substr(i, 1);
        caracterValue = value.substr(lenValue, 1);
        valor = findSymbol(caracter);
        if (valor == CARACTER || valor == SIGNAL)
            valueDelete = valueDelete + caracterValue;
        else if (valor == UPPER || valor == LOWER)
            --lenValue;
        else if (valor == SEPARATOR) {
            if (displayMask.charAt(i + 1) != caracterValue)
                valueDelete = valueDelete + caracterValue;
            ++i;
        }
        else
            if (caracter != caracterValue)
            valueDelete = valueDelete + caracterValue;
        ++lenValue;
        ++i;
    }
    return (valueDelete);
}

function formatString(value, displayMask) {
    if (value.length == 0)
        return value;
    value = deleteMaskString(value, displayMask);
    var formatValue = "";
    var lenValue = 0;
    var caracter;
    var symbol;
    var i = 0;
    var typeCase = OTHER;

    while (i < displayMask.length) {
        caracter = displayMask.charAt(i);

        symbol = findSymbol(caracter);
        if (symbol == SEPARATOR) {
            formatValue = formatValue + displayMask.substr(i + 1, 1);
            ++i;
        }
        else
            if (symbol == CARACTER) {
            if (value.length == lenValue)
                break;
            var check = validateCaracterString(value.substr(lenValue, 1), formatValue.length, displayMask);

            if (check) {
                var valueCaracter = value.substr(lenValue, 1);
                if (typeCase == UPPER)
                    valueCaracter = valueCaracter.toUpperCase();
                else
                    if (typeCase == LOWER)
                    valueCaracter = valueCaracter.toLowerCase()
                formatValue = formatValue + valueCaracter;
            }
            else
                --i;
            ++lenValue;
        }
        else
            if (symbol == UPPER)
            typeCase = UPPER;
        else {
            if (symbol == LOWER) {
                if (findSymbol(displayMask.substr(i + 1, 1)) == UPPER) {
                    typeCase = OTHER;
                    ++i;
                }
                else
                    typeCase = LOWER;
            }
            else
                if (lenValue < value.length)
                formatValue = formatValue + caracter;
        }
        ++i;
    }
    return (formatValue);
}

function formatValueString(field, displayMask, keyEvent) {
    var value = field.value;
    var valueFormated = formatString(value, displayMask);
    if (value != valueFormated)
        field.value = valueFormated;
}

function formatValueDate(field, displayMask, keyEvent) {
    var value = field.value;
    var valueFormated = formatDate(value, displayMask);
    if (value != valueFormated)
        field.value = valueFormated;
}