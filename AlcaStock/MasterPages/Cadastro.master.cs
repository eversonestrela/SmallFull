using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_Cadastro : System.Web.UI.MasterPage
{
    #region Propriedades

    public string Titulo
    {
        get { return lblTituloPagina.Text; }
        set { lblTituloPagina.Text = value; }
    }

    private string defaultFocus = string.Empty;

    public string DefaultFocusControlID
    {
        get
        {
            return defaultFocus;
        }
        set
        {
            defaultFocus = value;
        }
    }

    #endregion Propriedades
    protected void Page_Load(object sender, EventArgs e)
    {
        RegistrarDefaultFocus();

        if (!(Page is AppBasePage))
            throw new InvalidOperationException("Atenção, para uso desta master page, a content page deve herdar de AppBasePage.");
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }

    /// <summary>
    /// Registra o script de foco no controle que foi passado pela propriedade DefaultFocusControlID
    /// </summary>
    public void RegistrarDefaultFocus()
    {
        if (DefaultFocusControlID == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "foco", "function foco(){var f = 0;}", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "foco", "function foco(){document.all." + DefaultFocusControlID + ".focus();}", true);
        }
    }
}