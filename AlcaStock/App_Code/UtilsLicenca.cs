using System;
using System.Data;

public class UtilsLicenca
{
    #region Construtor
    public UtilsLicenca() { }
    #endregion Construtor

    #region Metodos

    private static int Ord(System.String Str)
    {
        return (int)Str[0];
    }

    /// <summary>
    /// Rotina que gera criptografia como numero de Serie
    /// </summary>
    /// <param name="Texto">string para criptografar ou descriptografar</param>
    /// <param name="Criptografa">True para criptografar ou False para descriptografar</param>
    /// <returns></returns>
    public static string Crip(string Texto, Boolean Criptografa)
    {
        // return Texto;
        int I, L, J, Aux, IDX;
        string R, VE, SAux, SP;
        string[] V = new string[10];
        R = string.Empty;
        SAux = string.Empty;

        // P-E-R-N-A-M-B-U-C-O
        V[0] = "P"; V[1] = "E"; V[2] = "R"; V[3] = "N";
        V[4] = "A"; V[5] = "M"; V[6] = "B"; V[7] = "U";
        V[8] = "C"; V[9] = "O";

        if (Criptografa)
        {
            IDX = Texto.Length;
            while (IDX > 9)
            {
                for (int i = 0; i < IDX; i++)
                {
                    Aux = 0;
                    L = IDX.ToString().Length;
                    for (int j = 0; j < L; j++)
                    {
                        Aux = Aux + Convert.ToInt32(IDX.ToString().Substring(j, 1));
                    }
                    IDX = Aux;
                }
            }

            VE = V[IDX];

            for (int i = 0; i < Texto.Length; i++)
            {
                Aux = Ord(Texto.Substring(i, 1)) + (IDX * 3);
                SAux = Aux.ToString();
                if (Aux < 10) { SAux = "0" + SAux; }
                if (Aux < 100) { SAux = "0" + SAux; }
                R = R + SAux;
            }

            SAux = "";
            SP = "";
            I = 1;

            while (I <= R.Length)
            {
                int MoD = (I - 1) % 6;
                if ((I > 1) && (MoD == 0)) SP = "-"; else SP = "";
                MoD = (I - 1) % 3;
                if ((I == 0) || (MoD == 0))
                {
                    SAux = SAux + SP + System.Uri.HexEscape((char)(Convert.ToInt32(R.Substring(I - 1, 3)))).Replace("%", "0");
                }
                I = I + 3;
            }
            SAux = VE + SAux;
        }
        else
        {
            IDX = 0;
            R = Texto.Replace("-", "");
            VE = "";
            SAux = R.Substring(0, 1);

            for (int i = 0; i <= 9; i++)
            {
                if (V[i] == SAux)
                {
                    VE = SAux;
                    IDX = i;
                    break;
                }
            }

            if (VE == "")
            {
                SAux = "Texto violado!, Não foi possível reconstruir criptografia!";
            }
            else
            {
                R = R.Substring(1, R.Length - 1);

                I = 1;
                SAux = string.Empty;

                while (I < R.Length)
                {
                    if ((I == 1) || ((I - 1) % 3 == 0))
                    {
                        Aux = int.Parse(R.Substring(I - 1, 3), System.Globalization.NumberStyles.AllowHexSpecifier);
                        if (Aux < 100) SAux = SAux + "0";
                        if (Aux < 10) SAux = SAux + "0";
                        SAux = SAux + Aux.ToString();
                    }
                    I = I + 3;
                }

                R = SAux;

                I = 1;
                SAux = string.Empty;
                while (I <= R.Length)
                {
                    if ((I == 1) || ((I - 1) % 3 == 0))
                    {
                        SAux = SAux + Utilitarios.chr(Convert.ToInt32(R.Substring(I - 1, 3)) - (IDX * 3));
                    }

                    I = I + 3;
                }
            }
        }
        return SAux;
    }

    public static bool VerificaIdParceiro(int ID)
    {
        string SQL = string.Empty;
        int BD_LICENCA_CLIENTE;
        int BD_LICENCA_PARCEIRO;
        string Assinatura = string.Empty;

        int AnoAtual = DateTime.Now.Year;
        int MesAtual = DateTime.Now.Month;

        DataTable dt;

        BD_LICENCA_CLIENTE = Convert.ToInt32(Utilitarios.Exec_StringSql_Return("SELECT COALESCE(BD,0) FROM PARAMETRO_SIS"));

        SQL = "SELECT COALESCE(BD,0)AS BD, ASSINATURA FROM ID_PARCEIRO " +
            " WHERE ID = " + ID.ToString() +
            " AND ANO = " + AnoAtual.ToString() +
            " AND MES = " + MesAtual.ToString();

        dt = Utilitarios.Pesquisar(SQL);

        bool retorno = false;

        if (dt.Rows.Count > 0)
        {
            BD_LICENCA_PARCEIRO = Convert.ToInt32(dt.Rows[0]["BD"]);
            Assinatura = dt.Rows[0]["ASSINATURA"].ToString();

            if (BD_LICENCA_CLIENTE == BD_LICENCA_PARCEIRO)
            {
                if (Assinatura.Equals(UtilsLicenca.getAssinaturaMesIdParceiro(ID, BD_LICENCA_CLIENTE, AnoAtual, MesAtual))) retorno = true;
                else retorno = false;
            }
            else
            {
                retorno = false;
            }
        }
        
        return retorno;
    }

    public static string getAssinaturaMesIdParceiro(int ID, int BD, int Ano, int Mes)
    {
        string SBD = Utilitarios.StrZero(BD, 3);
        string SANO = Ano.ToString();
        string SMES = Utilitarios.StrZero(Mes, 2);

        return UtilsLicenca.Crip(ID.ToString() + SBD + SANO + SMES, true);
    }

    #endregion Metodos
}