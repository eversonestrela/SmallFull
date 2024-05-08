<html>
    <head>
        <title>JavaScript - Contagem Regressiva</title>
        <style type=text/css>
            .texto { font-family: verdana; font-size: 12px; color: #000000;}
            .entrada{ font-family: verdana; font-size: 12px; color: #000000; background-color: #05bbcc;}
        </style>
    </head>
    <body onload=begintimer() bgcolor="#f5f5f5">
        <script>
            
            var limit= "<%=Session.Timeout %>" + ":00";

            if (document.images) {
                var parselimit = limit.split(":")
                parselimit = parselimit[0] * 60 + parselimit[1] * 1
            }

            function begintimer() {
                if (!document.images)
                    return

                if (parselimit == 1)
                    top.location.href="<%=ResolveClientUrl("~/Login/Login.aspx")%>"
                else {
                    parselimit -= 1
                    curmin = Math.floor(parselimit / 60)
                    cursec = parselimit % 60

                    if (cursec < 10)
                        cursec = "0" + cursec;
                    if (curmin != 0)
                        curtime = curmin + ":" + cursec;
                    else
                        curtime = cursec;
                    
                    document.getElementById('sessao').innerHTML = "Sua sessão será encerrada em: " + curtime;
                    setTimeout("begintimer()",1000)
                }
            }
            </script>
        <div id="sessao" name="sessao" style="font-size:11px;font-family:tahoma;height:20px;width:200px;"></div>
    </body>
</html> 