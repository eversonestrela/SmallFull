using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

public partial class Funcionarios : System.Web.UI.Page
{
    private const double DeducaoPorDependente = 189.59; // Valor atual de dedução por dependente para IRRF
    private const double DeducaoSimplificada = 564.80; // Valor de dedução simplificada

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OcultarLabels();
        }
    }

    private void OcultarLabels()
    {
        lblSalarioBruto.Visible = false;
        lblINSS.Visible = false;
        lblIRRF.Visible = false;
        lblLiquido.Visible = false;
        lblBaseCalculoINSS.Visible = false;
        lblBaseCalculoIRRF.Visible = false;
    }

    private void ExibirLabels()
    {
        lblSalarioBruto.Visible = true;
        lblINSS.Visible = true;
        lblIRRF.Visible = true;
        lblLiquido.Visible = true;
        lblBaseCalculoINSS.Visible = true;
        lblBaseCalculoIRRF.Visible = true;
    }

    protected void btnAgendar_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Agendamento/Agendar.aspx"));
    }

    protected void btnParametro_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Cadastros/Pesquisa.aspx"));
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Index/Inicial.aspx"));
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Write("Funcionário cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Response.Write("Erro ao salvar a foto: " + ex.Message);
        }
    }

    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        try
        {

            double outrosdescontos = Convert.ToDouble(string.IsNullOrEmpty(txtValor.Text) ? "0" : txtValor.Text);

            double salarioBruto = Convert.ToDouble(txtSalarioBruto.Text);
            int numeroDependentes = string.IsNullOrEmpty(txtQTDE.Text) ? 0 : Convert.ToInt32(txtQTDE.Text);
            bool isSimplified = CalculoSimplificado.Checked;

            double baseCalculoINSS;
            double inss = CalcularINSS(salarioBruto, out baseCalculoINSS);
            double baseCalculoIRRF;
            double irrf = CalcularIRRF(salarioBruto, inss, numeroDependentes, isSimplified, out baseCalculoIRRF);

            lblSalarioBruto.Text = salarioBruto.ToString("C", new CultureInfo("pt-BR"));
            lblINSS.Text = inss.ToString("C", new CultureInfo("pt-BR"));
            lblIRRF.Text = irrf.ToString("C", new CultureInfo("pt-BR"));
            lblLiquido.Text = (salarioBruto - inss - irrf - outrosdescontos).ToString("C", new CultureInfo("pt-BR"));
            lblBaseCalculoINSS.Text = baseCalculoINSS.ToString("C", new CultureInfo("pt-BR"));
            lblBaseCalculoIRRF.Text = baseCalculoIRRF.ToString("C", new CultureInfo("pt-BR"));

            ExibirLabels();
        }
        catch (Exception ex)
        {
            lblINSS.Text = "Erro: " + ex.Message;
            lblIRRF.Text = "Erro: " + ex.Message;
            ExibirLabels(); // Ainda exibir as mensagens de erro
        }
    }

    private double CalcularINSS(double salarioBruto, out double baseCalculoINSS)
    {
        DataTable tabelaPrevidencia = Utilitarios.Pesquisar("SELECT * FROM TABELA_PREVIDENCIA");
        double inss = 0.0;
        baseCalculoINSS = salarioBruto;

        foreach (DataRow row in tabelaPrevidencia.Rows)
        {
            double valorInicial = Convert.ToDouble(row["VALOR_INICIAL"]);
            double valorFinal = Convert.ToDouble(row["VALOR_FINAL"]);
            double perSegurado = Convert.ToDouble(row["PER_SEGURADO"]);

            if (salarioBruto > valorInicial)
            {
                double salarioConsiderado = Math.Min(salarioBruto, valorFinal) - valorInicial;
                inss += salarioConsiderado * (perSegurado / 100);
            }
        }

        return inss;
    }

    private double CalcularIRRF(double salarioBruto, double inss, int numeroDependentes, bool isSimplified, out double baseCalculoIRRF)
    {
        DataTable tabelaIRRF = Utilitarios.Pesquisar("SELECT * FROM TABELA_IRRF");
        baseCalculoIRRF = salarioBruto - inss - (numeroDependentes * DeducaoPorDependente);
        if (isSimplified)
        {
            baseCalculoIRRF -= DeducaoSimplificada;
        }

        double irrf = 0.0;

        foreach (DataRow row in tabelaIRRF.Rows)
        {
            double faixaInicial = Convert.ToDouble(row["FAIXA_INICIAL"]);
            double faixaFinal = Convert.ToDouble(row["FAIXA_FINAL"]);
            double aliquota = Convert.ToDouble(row["ALIQUOTA"]);
            double parcDeduzir = Convert.ToDouble(row["PARC_DEDUZIR"]);

            if (baseCalculoIRRF >= faixaInicial && baseCalculoIRRF <= faixaFinal)
            {
                irrf = baseCalculoIRRF * (aliquota / 100) - parcDeduzir;
                break;
            }
        }

        return irrf;
    }
}
