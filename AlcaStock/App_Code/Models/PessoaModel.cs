using System;

namespace Models
{
    public class PessoaModel
    {
        private int? _PESSOA_ID;
        private string _NOME;
        private string _CPF_CNPJ;
        private DateTime _DATA_NASC;
        private string _SEXO;
        private string _NOME_MAE;
        private string _CPF_MAE;
        private string _NOME_PAI;
        private string _CPF_PAI;
        private string _TELEFONE_RESIDENCIAL;
        private string _TELEFONE_CELULAR;
        private string _EMAIL;
        private string _SIS_USUARIO_INSERT;
        private DateTime? _SIS_DATA_INSERT;
        private string _SIS_USUARIO_UPDATE;
        private DateTime? _SIS_DATA_UPDATE;


        public int? PESSOA_ID
        {
            get { return _PESSOA_ID; }
            set { _PESSOA_ID = value; }
        }
        public string NOME
        {
            get { return _NOME; }
            set { _NOME = value; }
        }
        public string CPF
        {
            get { return _CPF_CNPJ; }
            set { _CPF_CNPJ = value; }
        }
        public DateTime DATA_NASC
        {
            get { return _DATA_NASC; }
            set { _DATA_NASC = value; }
        }
        public string SEXO
        {
            get { return _SEXO; }
            set { _SEXO = value; }
        }
        public string NOME_MAE
        {
            get { return _NOME_MAE; }
            set { _NOME_MAE = value; }
        }
        public string CPF_MAE
        {
            get { return _CPF_MAE; }
            set { _CPF_MAE = value; }
        }
        public string NOME_PAI
        {
            get { return _NOME_PAI; }
            set { _NOME_PAI = value; }
        }
        public string CPF_PAI
        {
            get { return _CPF_PAI; }
            set { _CPF_PAI = value; }
        }
        public string TELEFONE_RESIDENCIAL
        {
            get { return _TELEFONE_RESIDENCIAL; }
            set { _TELEFONE_RESIDENCIAL = value; }
        }
        public string TELEFONE_CELULAR
        {
            get { return _TELEFONE_CELULAR; }
            set { _TELEFONE_CELULAR = value; }
        }
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
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
    }
}