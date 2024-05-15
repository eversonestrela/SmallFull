function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_nbGroup(event, grpName) { //v6.0
  var i,img,nbArr,args=MM_nbGroup.arguments;
  if (event == "init" && args.length > 2) {
    if ((img = MM_findObj(args[2])) != null && !img.MM_init) {
      img.MM_init = true; img.MM_up = args[3]; img.MM_dn = img.src;
      if ((nbArr = document[grpName]) == null) nbArr = document[grpName] = new Array();
      nbArr[nbArr.length] = img;
      for (i=4; i < args.length-1; i+=2) if ((img = MM_findObj(args[i])) != null) {
        if (!img.MM_up) img.MM_up = img.src;
        img.src = img.MM_dn = args[i+1];
        nbArr[nbArr.length] = img;
    } }
  } else if (event == "over") {
    document.MM_nbOver = nbArr = new Array();
    for (i=1; i < args.length-1; i+=3) if ((img = MM_findObj(args[i])) != null) {
      if (!img.MM_up) img.MM_up = img.src;
      img.src = (img.MM_dn && args[i+2]) ? args[i+2] : ((args[i+1])? args[i+1] : img.MM_up);
      nbArr[nbArr.length] = img;
    }
  } else if (event == "out" ) {
    for (i=0; i < document.MM_nbOver.length; i++) {
      img = document.MM_nbOver[i]; img.src = (img.MM_dn) ? img.MM_dn : img.MM_up; }
  } else if (event == "down") {
    nbArr = document[grpName];
    if (nbArr)
      for (i=0; i < nbArr.length; i++) { img=nbArr[i]; img.src = img.MM_up; img.MM_dn = 0; }
    document[grpName] = nbArr = new Array();
    for (i=2; i < args.length-1; i+=2) if ((img = MM_findObj(args[i])) != null) {
      if (!img.MM_up) img.MM_up = img.src;
      img.src = img.MM_dn = (args[i+1])? args[i+1] : img.MM_up;
      nbArr[nbArr.length] = img;
  } }
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function MM_jumpMenu(targ,selObj,restore){ //v3.0
  eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}

function ImagesResize() {
  var obj = document.getElementsByTagName("div");
  for(var i = 0;i<obj.length;i++) {
    if (obj[i].className == "imgstyle") {
      var img = obj[i].getElementsByTagName("img");
      if (img[0].width > 100) { obj[i].innerHTML = '<img src="' + img[0].src + '" width="100" hspace="6" border="0">'; }
    }
  }
}


function ImagesResize2() {
  var obj = document.getElementsByTagName("div");
  for(var i = 0;i<obj.length;i++) {
    if (obj[i].className == "imgstyle2") {
      var img = obj[i].getElementsByTagName("img");
      if (img[0].width > 280) { obj[i].innerHTML = '<img src="' + img[0].src + '" width="280" border="1">'; }
    }
  }
}

function NewWindow(mypage,myname,w,h,scroll){
	LeftPosition = (screen.width) ? (screen.width-w)/2 : 0;
	TopPosition = (screen.height) ? (screen.height-h)/2 : 0;
	settings = 'height='+h+',width='+w+',top='+TopPosition+',left='+LeftPosition+',scrollbars='+scroll+',noresizable'
	win = window.open(mypage,myname,settings)
}

function ExibeFlash(w,h,wmode,movie) {
	document.write('<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" width="'+w+'" height="'+h+'">');
	document.write('<param name="wmode" value="'+wmode+'"/>');
	document.write('<param name="quality" value="high"/>');
	document.write('<param name="movie" value="'+movie+'"/>');
	document.write('<embed src="'+movie+'" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" wmode="'+wmode+'" width="'+w+'" height="'+h+'"></embed>');
	document.write('</object>');
}


/*** 
* Descrição.: formata um campo do formulário de 
* acordo com a máscara informada... 
* Parâmetros: - objForm (o Objeto Form) 
* - strField (string contendo o nome 
* do textbox) 
* - sMask (mascara que define o 
* formato que o dado será apresentado, 
* usando o algarismo "9" para 
* definir números e o símbolo "!" para 
* qualquer caracter... 
* - evtKeyPress (evento) 
* Uso.......: <input type="textbox" 
* name="xxx"..... 
* onkeypress="return txtBoxFormat(document.rcfDownload, 'str_cep', '99999-999', event);"> 
* Observação: As máscaras podem ser representadas como os exemplos abaixo: 
* CEP -> 99.999-999 
* CPF -> 999.999.999-99 
* CNPJ -> 99.999.999/9999-99 
* Data -> 99/99/9999 
* Tel Resid -> (99) 999-9999 
* Tel Cel -> (99) 9999-9999 
* Processo -> 99.999999999/999-99 
* C/C -> 999999-! 
* Hora -> 99:99
* E por aí vai... 
***/

function txtBoxFormat(objForm, strField, sMask, evtKeyPress) {
var i, nCount, sValue, fldLen, mskLen,bolMask, sCod, nTecla;

if(document.all) { // Internet Explorer
nTecla = evtKeyPress.keyCode; }
else if(document.layers) { // Nestcape
nTecla = evtKeyPress.which;
}

sValue = objForm[strField].value;

// Limpa todos os caracteres de formatação que
// já estiverem no campo.
sValue = sValue.toString().replace( "-", "" );
sValue = sValue.toString().replace( "-", "" );
sValue = sValue.toString().replace( ".", "" );
sValue = sValue.toString().replace( ".", "" );
sValue = sValue.toString().replace( "/", "" );
sValue = sValue.toString().replace( "/", "" );
sValue = sValue.toString().replace( "(", "" );
sValue = sValue.toString().replace( "(", "" );
sValue = sValue.toString().replace( ")", "" );
sValue = sValue.toString().replace( ")", "" );
sValue = sValue.toString().replace( " ", "" );
sValue = sValue.toString().replace( " ", "" );
sValue = sValue.toString().replace( ":", "" );
sValue = sValue.toString().replace( ":", "" );
fldLen = sValue.length;
mskLen = sMask.length;

i = 0;
nCount = 0;
sCod = "";
mskLen = fldLen;

while (i <= mskLen) {
bolMask = ((sMask.charAt(i) == "-") || (sMask.charAt(i) == ".") || (sMask.charAt(i) == "/"))
bolMask = bolMask || ((sMask.charAt(i) == "(") || (sMask.charAt(i) == ")") || (sMask.charAt(i) == " ") || (sMask.charAt(i) == ":"))

if (bolMask) {
sCod += sMask.charAt(i);
mskLen++; }
else {
sCod += sValue.charAt(nCount);
nCount++;
}

i++;
}

objForm[strField].value = sCod;

if (nTecla != 8) { // backspace
if (sMask.charAt(i-1) == "9") { // apenas números...
return ((nTecla > 47) && (nTecla < 58)); } // números de 0 a 9
else { // qualquer caracter...
return true;
} }
else {
return true;
}
}
//Fim da Função Máscaras Gerais


function Limpar(valor, validos) {
// retira caracteres invalidos da string
var result = "";
var aux;
for (var i=0; i < valor.length; i++) {
aux = validos.indexOf(valor.substring(i, i+1));
if (aux>=0) {
result += aux;
}
}
return result;
}

//Formata número tipo moeda usando o evento onKeyDown

function Formata(campo,tammax,teclapres,decimal) {
var tecla = teclapres.keyCode;
vr = Limpar(campo.value,"0123456789");
tam = vr.length;
dec=decimal

if (tam < tammax && tecla != 8){ tam = vr.length + 1 ; }

if (tecla == 8 )
{ tam = tam - 1 ; }

if ( tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105 )
{

if ( tam <= dec )
{ campo.value = vr ; }

if ( (tam > dec) && (tam <= 5) ){
campo.value = vr.substr( 0, tam - 2 ) + "," + vr.substr( tam - dec, tam ) ; }
if ( (tam >= 6) && (tam <= 8) ){
campo.value = vr.substr( 0, tam - 5 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - dec, tam ) ; 
}
if ( (tam >= 9) && (tam <= 11) ){
campo.value = vr.substr( 0, tam - 8 ) + "." + vr.substr( tam - 8, 3 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - dec, tam ) ; }
if ( (tam >= 12) && (tam <= 14) ){
campo.value = vr.substr( 0, tam - 11 ) + "." + vr.substr( tam - 11, 3 ) + "." + vr.substr( tam - 8, 3 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - dec, tam ) ; }
if ( (tam >= 15) && (tam <= 17) ){
campo.value = vr.substr( 0, tam - 14 ) + "." + vr.substr( tam - 14, 3 ) + "." + vr.substr( tam - 11, 3 ) + "." + vr.substr( tam - 8, 3 ) + "." + vr.substr( tam - 5, 3 ) + "," + vr.substr( tam - 2, tam ) ;}
} 

}


function openAjax() { 
var Ajax; 
try {Ajax = new XMLHttpRequest(); // XMLHttpRequest para browsers mais populares, como: Firefox, Safari, dentre outros. 
}catch(ee) { 
try {Ajax = new ActiveXObject("Msxml2.XMLHTTP"); // Para o IE da MS 
}catch(e) { 
try {Ajax = new ActiveXObject("Microsoft.XMLHTTP"); // Para o IE da MS 
}catch(e) {Ajax = false; 
} 
} 
} 
return Ajax; 
} 

function carregaAjax(id, site) { 
	if(document.getElementById) { // Para os browsers complacentes com o DOM W3C. 
		var exibeResultado = document.getElementById(id); // div que exibirá o resultado. 
		var Ajax = openAjax(); // Inicia o Ajax. 
		Ajax.open("GET", site, true); // fazendo a requisiçao 
		Ajax.onreadystatechange = function() 
	{ 
	if(Ajax.readyState == 1) { // Quando estiver carregando, exibe: carregando... 
		exibeResultado.innerHTML = "<br>&nbsp;&nbsp;&nbsp;&nbsp;<img src='images/indicator.gif' align=absmiddle> <span class='arial_preto'>Aguarde Carregando ...</span>"; 
} 
if(Ajax.readyState == 4) { // Quando estiver tudo pronto. 
	if(Ajax.status == 200) { 
		var resultado = Ajax.responseText; // Coloca o retornado pelo Ajax nessa variável 
		resultado = resultado.replace(/\+/g," "); // Resolve o problema dos acentos (saiba mais aqui: http://www.plugsites.net/leandro/?p=4) 
		//resultado = encodeURIComponent(resultado);
		resultado = unescape(resultado); // Resolve o problema dos acentos 
		exibeResultado.innerHTML = resultado; 
	} else { 
	exibeResultado.innerHTML = "Erro: ."; 
		} 
	} 
} 
Ajax.send(null); // submete 
}
}
