using System.Web.UI.WebControls;

namespace ALCASTOCK.Geral
{
    /// <summary>
    /// Summary description for Utilities.
    /// </summary>
    public class TratarEntradadeDados
    {
        #region Filter DropDowmList

        public static void SetFilterDropdownlist(DropDownList combo)
        {
            combo.Attributes.Add("Filtro", "0");
            combo.Attributes.Add("OldFiltro", "0");
            combo.Attributes.Add("Posicao", "0");
            combo.Attributes.Add("OldSelectedIndex", "0");
            combo.Attributes.Add("onfocus", "javascript:SetValueInitial(this);");
            combo.Attributes.Add("onkeydown", "javascript:RemoveFilter(this);");
            combo.Attributes.Add("onkeypress", "javascript:Filter(this); return false;");
            combo.Attributes.Add("onblur", "javascript:this.Filtro='0'; removeElement(this);");
        }


        public static void SetFilterDropdownlist(DropDownList combo, bool AutoPostBack)
        {
            combo.Attributes.Add("Filtro", "0");
            combo.Attributes.Add("OldFiltro", "0");
            combo.Attributes.Add("Posicao", "0");
            combo.Attributes.Add("OldSelectedIndex", "0");
            combo.Attributes.Add("onfocus", "javascript:SetValueInitial(this);");
            combo.Attributes.Add("onkeydown", "javascript:RemoveFilter(this);");
            combo.Attributes.Add("onkeypress", "javascript:Filter(this); return false;");
            combo.Attributes["onblur"] = (AutoPostBack) ? "javascript:this.Filtro='0'; removeElement(this); executeEventOnChange(this);" : "javascript:this.Filtro='0'; removeElement(this);";
        }

        #endregion

        #region Tratamento de Texto
        public static void Upper(TextBox txt1)
        {
            txt1.Style.Add("TEXT-TRANSFORM", "uppercase");
        }

        public static void CEP(TextBox txt1)
        {
            txt1.Attributes.Add("onkeydown", "javascript:mascara_CEP();");
            txt1.Attributes.Add("MaxLength", "10;");
        }

        public static void CPF(TextBox txt1)
        {
            txt1.Attributes.Add("onkeypress", "javascript:formataCpf(this, event);");
            txt1.Attributes.Add("onchange", "javascript:formataCpf(this, event);");
            txt1.Attributes.Add("onblur", "javascript:saidaCpfCnpj(this, true, true, 'cpf');ExitCPF();");
            txt1.Attributes.Add("MaxLength", "14");
        }

        public static void CNPJ(TextBox txt1)
        {
            txt1.Attributes.Add("onkeypress", "javascript:formataCnpj(this, event);");
            txt1.Attributes.Add("onblur", "javascript:saidaCpfCnpj(this, true, true, 'cnpj');");
            txt1.Attributes.Add("MaxLength", "18;");
        }

        public static void MONEY(TextBox txt1)
        {
            txt1.Attributes.Add("onkeypress", "javascript:FormataMoney(this, 20, event, 2);");
        }

        #endregion

        #region Tratamento de Telefone
        public static void MascaraCelular(TextBox txt1)
        {
            txt1.Attributes.Add("onkeypress", "javascript:formatPhoneNumber(this);");
            txt1.Attributes.Add("MaxLength", "11");
        }
        #endregion

        #region Tratamento de Data

        public static void MascaraData(TextBox txt1)
        {
            txt1.Attributes.Add("onkeydown", "javascript:mascara_Data();");
        }
        public static void MascaraData(eWorld.UI.CalendarPopup txt1)
        {
            txt1.Attributes.Add("onkeydown", "javascript:mascara_Data();");
        }
        #endregion
    }
}