using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using System.Data;
using System.Activities.Statements;
using System.Web.Services.Description;
using System.Linq;

public partial class PageIndex : System.Web.UI.Page
{
   
        protected void Page_Load(object sender, EventArgs e)
        {


        btnSalvar.Visible = false;
        txtNome.Visible =  false;
        GenerateDateButtons();

    }


    private void GenerateDateButtons()
    {
        DateTime startDate = DateTime.Now; // Datainicial
        DateTime endDate = DateTime.Now.AddDays(7); // Exemplo: próxima semana

        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            Button btnDate = new Button();
            btnDate.Text = date.ToString("dd"); // Formato do texto do botão
            btnDate.CommandArgument = date.ToShortDateString();
            btnDate.Click += new EventHandler(DateButton_Click);
            pnlDates.Controls.Add(btnDate);
        }
    }

    private void DateButton_Click(object sender, EventArgs e)
    {
        string SQL = string.Empty;
        Button clickedButton = (Button)sender;
        DateTime selectedDate = DateTime.Parse(clickedButton.CommandArgument);
        GenerateTimeButtons(selectedDate);


        SQL = @"
        SELECT 
    
        ";
    
    }
    private void GenerateTimeButtons(DateTime date)
    {
        // Limpar horários antigos
        pnlTimes.Controls.Clear();

        // Definindo o horário inicial e final
        TimeSpan startTime = new TimeSpan(8, 0, 0); // 08:00
        TimeSpan endTime = new TimeSpan(18, 30, 0); // 18:00
        TimeSpan interval = new TimeSpan(0, 30, 0); // intervalo de 30 minutos

        // Gerando todos os horários entre o início e o fim no intervalo especificado
        for (TimeSpan time = startTime; time <= endTime; time += interval)
        {
            Button btnTime = new Button();
            btnTime.Text = time.ToString(@"hh\:mm"); // Formato do texto do botão
            btnTime.CssClass = "button-style"; // Aplicar estilo, se houver
            btnTime.CommandArgument = date.Add(time).ToString();
            btnTime.Click += new EventHandler(TimeButton_Click);
            pnlTimes.Controls.Add(btnTime);
        }
    }


    private void TimeButton_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        DateTime selectedDateTime = DateTime.Parse(clickedButton.CommandArgument);
        // Agora você tem a data e hora selecionada para usar como quiser

   
    }



    protected void SomeButton_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    }


    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Index/Inicial.aspx"));
    }

    protected void btnParametro_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Cadastros/Pesquisa.aspx"));
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
        {
            // Lógica para salvar o cadastro
            string nome = txtNome.Text;
            // Aqui você pode inserir a lógica para salvar o nome no banco de dados, por exemplo.
            // Exemplo simples de feedback
          //  Response.Write($"Cadastro salvo com sucesso! Nome: {nome}");
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "MSG", "<script type=\"text/javascript\">alert('Teste';</script>", false);
    }

    protected void btnAgendar_Click(object sender, EventArgs e)
    {
           


    }
   
        
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        // Determine qual LinkButton foi clicado
        LinkButton linkButton = (LinkButton)sender;

        // Obtenha o comando de argumento (ID do profissional) associado ao LinkButton clicado
        int profissionalId = Convert.ToInt32(linkButton.CommandArgument);


        if(profissionalId > 0)
        {
            pnlDates.Visible=true;
            pnlTimes.Visible = true;
        }

        AgendaProfissional(profissionalId);


        if (profissionalId == 2) // MILENE
        { 
            //LinkButton4.Visible = true;
        }
        else
        {
           // LinkButton4.Visible = false;
        }

        if (profissionalId == 4) // MATHEUS
        {
            Visagista.Visible = true;
        }
        else
        {
            Visagista.Visible = false;
        }
        if (profissionalId == 3) //ISAQUE
        {
            Visagista.Visible = true;
        }
        else
        {
            Visagista.Visible = false;
        }


    }

 

    protected void AgendaProfissional(int profissionalId)
    {

        try
        {
            DataTable dt = Utilitarios.Pesquisar("SELECT NOME FROM Profissionais WHERE PROFISSIONAL_ID=" + profissionalId);

            lblNomeProfissional.Visible=true; 
            lblNomeProfissional.Text = dt.Rows[0]["NOME"].ToString();

            if (dt.Rows.Count > 0)
            {
                lblNomeProfissional.Text = dt.Rows[0]["NOME"].ToString();

                DataTable dt2 = Utilitarios.Pesquisar("SELECT  CONVERT(VARCHAR(5),HORARIO_DISPONIVEL)  + ' -- ' +CONVERT(VARCHAR(10),DATA_DISPONIVEL,103) AS HORARIO_DISPONIVEL FROM HORARIO_DISPONIVEL WHERE PROFISSIONAL_ID=" + profissionalId);


                if (dt2.Rows.Count > 0)
                {
                    // lblHorario.Text = dt2.Rows[0]["HORARIO_DISPONIVEL"].ToString();
                }

            }
        }
        catch {

            

            ScriptManager.RegisterStartupScript(this, GetType(), "al", "alert('Dados do profissional não encontrado, contate o SUPORTE!  Profissional_ID: " + profissionalId + " ')", true);

        }

    }

    protected void Service_Click(object sender, EventArgs e)
    {
        lblNomeProfissional.Visible = true;
     

    }



    protected void CalendarDatas_SelectionChanged(object sender, EventArgs e)
    {
 


    }

    protected void DropDownHorarios_SelectedIndexChanged(object sender, EventArgs e)
    {

     

    }

    protected void DropDownBarbeiros_SelectIndexChanged(object sender, EventArgs e)
    {

 

    }

    protected void ConfirmarAgenda_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = (LinkButton)sender;
        int profissionalId = Convert.ToInt32(linkButton.CommandArgument);
        //DateTime dataSelecionada = CalendarDatas.SelectedDate;
       

    }




}
