/* var _VReportTable = '<table id="_VReportTable"><thead><tr><th id="_VReportTHead">&nbsp;</th></tr></thead><tfoot><tr><th id="_VReportTFoot">&nbsp;</th></tr></tfoot><tbody><tr><td valign="top"><div id="_VReportContentClient"></div></td></tr></tbody></table>';
var _VReportContentClient = document.getElementById('_VReportContent').innerHTML;
document.getElementById('_VReportContent').innerHTML = _VReportTable;
document.getElementById('_VReportContentClient').innerHTML = _VReportContentClient;
document.getElementById('_VReportTHead').style.height = document.getElementById('_VReportHeader').clientHeight + "px";
document.getElementById('_VReportTFoot').style.height = document.getElementById('_VReportFooter').clientHeight + "px";
document.getElementById('_VReportContent').style.margin = "0 0 0 0"; */

qs = new Array()
variaveis = location.search.replace(/\x3F/, "").replace(/\x2B/g, " ").split("&")
if (variaveis != "") {
    for (i = 0; i < variaveis.length; i++) {
        nvar = variaveis[i].split("=")
        qs[nvar[0]] = unescape(nvar[1])
    }
}
function QueryString(variavel) {
    return qs[variavel]
}

if (QueryString('SisprevEmissao') != '') {
    window.print();
    window.moveTo(0, 0);
    window.resizeTo(screen.availWidth, screen.availHeight);
}