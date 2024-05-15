using System;

public partial class MasterPages_Consulta : System.Web.UI.MasterPage
{
    #region Propriedades
    /// <summary>
    /// Titulo da página de consulta.
    /// Ex: ((MasterPage)Master).Titulo = "Consulta de Pessoas";
    /// </summary>
    public string Titulo
    {
        get { return lblTituloPagina.Text; }
        set { lblTituloPagina.Text = value; }
    }
    #endregion Propriedades

    protected void Page_Load(object sender, EventArgs e)
    {
        Utilitarios.AtribuirFuncoesJava(Parent.Page);

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
}