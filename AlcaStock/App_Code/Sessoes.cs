using System.Web;

/// <summary>
/// Summary description for Session
/// </summary>
public class Sessoes
{
    public Sessoes()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string IP
    {
        get
        {
            string _ip = string.Empty;

            if (HttpContext.Current.Session["IP"] != null)
                _ip = HttpContext.Current.Session["IP"].ToString();

            return _ip;
        }
        set
        {
            HttpContext.Current.Session["IP"] = value;
        }
    }

    public static string IP_ANTERIOR
    {
        get
        {
            string _ip_anterior = string.Empty;

            if (HttpContext.Current.Session["IP_ANTERIOR"] != null)
                _ip_anterior = HttpContext.Current.Session["IP_ANTERIOR"].ToString();

            return _ip_anterior;
        }
        set
        {
            HttpContext.Current.Session["IP_ANTERIOR"] = value;
        }
    }

    public static string SESSION_ID
    {
        get
        {
            string _session_id = string.Empty;

            if (HttpContext.Current.Session["SESSION_ID"] != null)
                _session_id = HttpContext.Current.Session["SESSION_ID"].ToString();

            return _session_id;
        }
        set
        {
            HttpContext.Current.Session["SESSION_ID"] = value;
        }
    }

    public static int USR_LOGIN_ID
    {
        get
        {
            int _login = 0;

            if (HttpContext.Current.Session["USR_LOGIN_ID"] != null)
                _login = (int)HttpContext.Current.Session["USR_LOGIN_ID"];

            return _login;
        }
        set
        {
            HttpContext.Current.Session["USR_LOGIN_ID"] = value;
        }
    }
}
