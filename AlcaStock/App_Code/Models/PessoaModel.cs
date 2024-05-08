using System;

namespace Models
{
    public class PessoaModel
    {
        private int? _PESSOA_ID;

        private string _CPF;

        private string _NOME;

        private DateTime _DATA_NASC;

        private string _NOME_MAE;

        private string _SEXO;

        private string _NOME_PAI;

        private int? _NAT_CIDADE_ID;

        private int? _ESTADO_CIVIL;

        private int? _NACIONALIDADE_ID;

        private int? _RACA_ID;

        private string _RG_NUMERO;

        private string _RG_UF;

        private string _RG_ORGAO;

        private DateTime? _RG_DT_EMISSAO;

        private string _PIS;

        private string _NIT;

        private string _TITULO_NR;

        private string _TITULO_ZONA;

        private string _TITULO_SECAO;

        private string _CTPS_NUMERO;

        private string _CTPS_SERIE;

        private string _CTPS_UF;

        private DateTime? _CTPS_DT_EMISSAO;

        private string _CTPS_LOCAL_EXP;

        private string _END_UF;

        private int? _END_CIDADE_ID;

        private string _END_BAIRRO;

        private string _END_RUA;

        private string _END_NUMERO;

        private string _END_COMPLEMENTO;

        private string _FONE_RESIDENCIAL;

        private string _FONE_CELULAR;

        private string _PORTADOR_MOLESTIA;

        private string _EMAIL1;

        private string _EMAIL2;

        private string _OBS;

        private string _SIS_USUARIO_INSERT;

        private DateTime? _SIS_DATA_INSERT;

        private string _SIS_USUARIO_UPDATE;

        private DateTime? _SIS_DATA_UPDATE;

        private string _USUARIO_ALTEROU_TMP;

        private DateTime? _DATA_ALTEROU_TMP;

        private string _END_CEP;

        private string _RAZAO_SOCIAL;

        private string _INSC_ESTADUAL;

        private string _INSC_MUNICIPAL;

        private string _TIPO_PESSOA;

        private string _CONTATO;

        private int? _ESCOLARIDADE_ID;

        private string _PLANO_SAUDE;

        private string _TERCEIROS;

        private string _ISENTO_CONTRIB;

        private string _FONE_COMERCIAL;

        private string _ALVARA;

        private DateTime? _ALVARA_DATA_EMISSAO;

        private DateTime? _ALVARA_DATA_VALIDADE;

        private string _MATRICULA_BANESTES;

        private string _ABREVIACAO_NOME;

        private int _ORGAO_SETOR;

        private string _RESERVISTA;

        private string _CNH;

        private string _CONSELHO_CART_PROF;

        private string _NUMERO_CART_PROF;

        private string _CIDADE_EXTERIOR;

        private string _ESTADO_EXTERIOR;

        private string _CAIXA_POSTAL_EXTERIOR;

        private int _PAIS_ID;

        private string _NATURALIDADE_EXTERIOR;

        private string _CPF_MAE;

        private string _CPF_PAI;

        private string _PORTADOR_NECESSIDADES_ESP;

        private string _AGENDAMENTO_VISITA;

        private DateTime? _DATA_ULT_AGENDAMENTO_VISITA;

        private string _NATURALIZADO;

        private string _EXTRANGEIRO_NATURALIZADO;

        private string _PROFISSAO;

        private int _TIPO_LOGRADOURO;

        public int? PESSOA_ID
        {
            get { return _PESSOA_ID; }
            set { _PESSOA_ID = value; }
        }

        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; }
        }

        public string NOME
        {
            get { return _NOME; }
            set { _NOME = value; }
        }

        public DateTime DATA_NASC
        {
            get { return _DATA_NASC; }
            set { _DATA_NASC = value; }
        }

        public string NOME_MAE
        {
            get { return _NOME_MAE; }
            set { _NOME_MAE = value; }
        }

        public string SEXO
        {
            get { return _SEXO; }
            set { _SEXO = value; }
        }

        public string NOME_PAI
        {
            get { return _NOME_PAI; }
            set { _NOME_PAI = value; }
        }

        public int? NAT_CIDADE_ID
        {
            get { return _NAT_CIDADE_ID; }
            set { _NAT_CIDADE_ID = value; }
        }

        public int? NACIONALIDADE_ID
        {
            get { return _NACIONALIDADE_ID; }
            set { _NACIONALIDADE_ID = value; }
        }

        public string RG_UF
        {
            get { return _RG_UF; }
            set { _RG_UF = value; }
        }

        public int? RACA_ID
        {
            get { return _RACA_ID; }
            set { _RACA_ID = value; }
        }

        public int? ESTADO_CIVIL
        {
            get { return _ESTADO_CIVIL; }
            set { _ESTADO_CIVIL = value; }
        }

        public string RG_NUMERO
        {
            get { return _RG_NUMERO; }
            set { _RG_NUMERO = value; }
        }

        public string RG_ORGAO
        {
            get { return _RG_ORGAO; }
            set { _RG_ORGAO = value; }
        }

        public DateTime? RG_DT_EMISSAO
        {
            get { return _RG_DT_EMISSAO; }
            set { _RG_DT_EMISSAO = value; }
        }

        public string PIS
        {
            get { return _PIS; }
            set { _PIS = value; }
        }

        public string NIT
        {
            get { return _NIT; }
            set { _NIT = value; }
        }

        public string TITULO_NR
        {
            get { return _TITULO_NR; }
            set { _TITULO_NR = value; }
        }

        public string TITULO_ZONA
        {
            get { return _TITULO_ZONA; }
            set { _TITULO_ZONA = value; }
        }

        public string TITULO_SECAO
        {
            get { return _TITULO_SECAO; }
            set { _TITULO_SECAO = value; }
        }

        public string CTPS_NUMERO
        {
            get { return _CTPS_NUMERO; }
            set { _CTPS_NUMERO = value; }
        }

        public string CTPS_SERIE
        {
            get { return _CTPS_SERIE; }
            set { _CTPS_SERIE = value; }
        }

        public string CTPS_UF
        {
            get { return _CTPS_UF; }
            set { _CTPS_UF = value; }
        }

        public DateTime? CTPS_DT_EMISSAO
        {
            get { return _CTPS_DT_EMISSAO; }
            set { _CTPS_DT_EMISSAO = value; }
        }

        public string CTPS_LOCAL_EXP
        {
            get { return _CTPS_LOCAL_EXP; }
            set { _CTPS_LOCAL_EXP = value; }
        }

        public string END_UF
        {
            get { return _END_UF; }
            set { _END_UF = value; }
        }

        public int? END_CIDADE_ID
        {
            get { return _END_CIDADE_ID; }
            set { _END_CIDADE_ID = value; }
        }

        public string END_BAIRRO
        {
            get { return _END_BAIRRO; }
            set { _END_BAIRRO = value; }
        }

        public string END_RUA
        {
            get { return _END_RUA; }
            set { _END_RUA = value; }
        }

        public string END_NUMERO
        {
            get { return _END_NUMERO; }
            set { _END_NUMERO = value; }
        }

        public string END_COMPLEMENTO
        {
            get { return _END_COMPLEMENTO; }
            set { _END_COMPLEMENTO = value; }
        }

        public string FONE_RESIDENCIAL
        {
            get { return _FONE_RESIDENCIAL; }
            set { _FONE_RESIDENCIAL = value; }
        }

        public string FONE_CELULAR
        {
            get { return _FONE_CELULAR; }
            set { _FONE_CELULAR = value; }
        }

        public string PORTADOR_MOLESTIA
        {
            get { return _PORTADOR_MOLESTIA; }
            set { _PORTADOR_MOLESTIA = value; }
        }

        public string EMAIL1
        {
            get { return _EMAIL1; }
            set { _EMAIL1 = value; }
        }

        public string EMAIL2
        {
            get { return _EMAIL2; }
            set { _EMAIL2 = value; }
        }

        public string OBS
        {
            get { return _OBS; }
            set { _OBS = value; }
        }

        public string SIS_USUARIO_INSERT
        {
            get { return _SIS_USUARIO_INSERT; }
            set { _SIS_USUARIO_INSERT = value; }
        }

        public DateTime? SIS_DATA_INSERT
        {
            get { return _SIS_DATA_INSERT; }
            set { _SIS_DATA_INSERT = value; }
        }

        public string SIS_USUARIO_UPDATE
        {
            get { return _SIS_USUARIO_UPDATE; }
            set { _SIS_USUARIO_UPDATE = value; }
        }

        public DateTime? SIS_DATA_UPDATE
        {
            get { return _SIS_DATA_UPDATE; }
            set { _SIS_DATA_UPDATE = value; }
        }

        public string USUARIO_ALTEROU_TMP
        {
            get { return _USUARIO_ALTEROU_TMP; }
            set { _USUARIO_ALTEROU_TMP = value; }
        }

        public DateTime? DATA_ALTEROU_TMP
        {
            get { return _DATA_ALTEROU_TMP; }
            set { _DATA_ALTEROU_TMP = value; }
        }

        public string END_CEP
        {
            get { return _END_CEP; }
            set { _END_CEP = value; }
        }

        public string RAZAO_SOCIAL
        {
            get { return _RAZAO_SOCIAL; }
            set { _RAZAO_SOCIAL = value; }
        }

        public string INSC_ESTADUAL
        {
            get { return _INSC_ESTADUAL; }
            set { _INSC_ESTADUAL = value; }
        }

        public string INSC_MUNICIPAL
        {
            get { return _INSC_MUNICIPAL; }
            set { _INSC_MUNICIPAL = value; }
        }

        public string TIPO_PESSOA
        {
            get { return _TIPO_PESSOA; }
            set { _TIPO_PESSOA = value; }
        }

        public string CONTATO
        {
            get { return _CONTATO; }
            set { _CONTATO = value; }
        }

        public int? ESCOLARIDADE_ID
        {
            get { return _ESCOLARIDADE_ID; }
            set { _ESCOLARIDADE_ID = value; }
        }

        public string PLANO_SAUDE
        {
            get { return _PLANO_SAUDE; }
            set { _PLANO_SAUDE = value; }
        }

        public string TERCEIROS
        {
            get { return _TERCEIROS; }
            set { _TERCEIROS = value; }
        }

        public string ISENTO_CONTRIB
        {
            get { return _ISENTO_CONTRIB; }
            set { _ISENTO_CONTRIB = value; }
        }

        public string FONE_COMERCIAL
        {
            get { return _FONE_COMERCIAL; }
            set { _FONE_COMERCIAL = value; }
        }

        public string ALVARA
        {
            get { return _ALVARA; }
            set { _ALVARA = value; }
        }

        public DateTime? ALVARA_DATA_EMISSAO
        {
            get { return _ALVARA_DATA_EMISSAO; }
            set { _ALVARA_DATA_EMISSAO = value; }
        }

        public DateTime? ALVARA_DATA_VALIDADE
        {
            get { return _ALVARA_DATA_VALIDADE; }
            set { _ALVARA_DATA_VALIDADE = value; }
        }

        public string MATRICULA_BANESTES
        {
            get { return _MATRICULA_BANESTES; }
            set { _MATRICULA_BANESTES = value; }
        }

        public string ABREVIACAO_NOME
        {
            get { return _ABREVIACAO_NOME; }
            set { _ABREVIACAO_NOME = value; }
        }

        public int ORGAO_SETOR
        {
            get { return _ORGAO_SETOR; }
            set { _ORGAO_SETOR = value; }
        }

        public string RESERVISTA
        {
            get { return _RESERVISTA; }
            set { _RESERVISTA = value; }
        }

        public string CNH
        {
            get { return _CNH; }
            set { _CNH = value; }
        }

        public string CONSELHO_CART_PROF
        {
            get { return _CONSELHO_CART_PROF; }
            set { _CONSELHO_CART_PROF = value; }
        }

        public string NUMERO_CART_PROF
        {
            get { return _NUMERO_CART_PROF; }
            set { _NUMERO_CART_PROF = value; }
        }

        public string CIDADE_EXTERIOR
        {
            get { return _CIDADE_EXTERIOR; }
            set { _CIDADE_EXTERIOR = value; }
        }

        public string ESTADO_EXTERIOR
        {
            get { return _ESTADO_EXTERIOR; }
            set { _ESTADO_EXTERIOR = value; }
        }

        public string CAIXA_POSTAL_EXTERIOR
        {
            get { return _CAIXA_POSTAL_EXTERIOR; }
            set { _CAIXA_POSTAL_EXTERIOR = value; }
        }

        public int PAIS_ID
        {
            get { return _PAIS_ID; }
            set { _PAIS_ID = value; }
        }

        public string NATURALIDADE_EXTERIOR
        {
            get { return _NATURALIDADE_EXTERIOR; }
            set { _NATURALIDADE_EXTERIOR = value; }
        }

        public string CPF_MAE
        {
            get { return _CPF_MAE; }
            set { _CPF_MAE = value; }
        }

        public string CPF_PAI
        {
            get { return _CPF_PAI; }
            set { _CPF_PAI = value; }
        }

        public string PORTADOR_NECESSIDADES_ESP
        {
            get { return _PORTADOR_NECESSIDADES_ESP; }
            set { _PORTADOR_NECESSIDADES_ESP = value; }
        }

        public string AGENDAMENTO_VISITA
        {
            get { return _AGENDAMENTO_VISITA; }
            set { _AGENDAMENTO_VISITA = value; }
        }

        public DateTime? DATA_ULT_AGENDAMENTO_VISITA
        {
            get { return _DATA_ULT_AGENDAMENTO_VISITA; }
            set { _DATA_ULT_AGENDAMENTO_VISITA = value; }
        }

        public string NATURALIZADO
        {
            get { return _NATURALIZADO; }
            set { _NATURALIZADO = value; }
        }

        public string ESTRANGEIRO_NATURALIZADO
        {
            get
            {
                return _EXTRANGEIRO_NATURALIZADO;
            }

            set
            {
                _EXTRANGEIRO_NATURALIZADO = value;
            }
        }

        public string PROFISSAO
        {
            get { return _PROFISSAO; }
            set { _PROFISSAO = value; }
        }

        public int TIPO_LOGRADOURO
        {
            get { return _TIPO_LOGRADOURO; }
            set { _TIPO_LOGRADOURO = value; }
        }
    }
}