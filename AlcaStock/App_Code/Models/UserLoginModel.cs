using System;

namespace Models
{
    public class UserLoginModel
    {
        private int? _USR_LOGIN_ID;

        private int? _PESSOA_ID;

        private string _LOGIN;

        private string _HASH;

        private int? _ORGAO_ID;

        private int? _USR_GRUPO_ID;

        private int? _CLIENTE_ID;

        private DateTime? _DATA_PRIMEIRO_ACESSO;

        private string _VERIFICA_COOOKIE;

        private DateTime? _DATA_VALIDADE;

        private int? _CODIGO_CLIENTE;

        private int? _CONFIG_PLANO_CLIENTE_ID;

        private string _MASTER;

        private int? _SEGURADO_ID;

        private string _FONTE_PAG_ID;

        private string _CATEGORIA_EFETIVO;

        private string _CATEGORIA_INATIVO;

        private string _CATEGORIA_PENSIONISTA;

        private int? _SETOR_ID;

        private string _SETOR;

        private string _HORA_INI;

        private string _HORA_FIM;

        private string _DATA;

        public int? USR_LOGIN_ID
        {
            get { return _USR_LOGIN_ID; }
            set { _USR_LOGIN_ID = value; }
        }

        public int? PESSOA_ID
        {
            get { return _PESSOA_ID; }
            set { _PESSOA_ID = value; }
        }

        public string LOGIN
        {
            get { return _LOGIN; }
            set { _LOGIN = value; }
        }

        public string HASH
        {
            get { return _HASH; }
            set { _HASH = value; }
        }

        public int? ORGAO_ID
        {
            get { return _ORGAO_ID; }
            set { _ORGAO_ID = value; }
        }

        public int? USR_GRUPO_ID
        {
            get { return _USR_GRUPO_ID; }
            set { _USR_GRUPO_ID = value; }
        }

        public int? CLIENTE_ID
        {
            get { return _CLIENTE_ID; }
            set { _CLIENTE_ID = value; }
        }

        public DateTime? DATA_PRIMEIRO_ACESSO
        {
            get { return _DATA_PRIMEIRO_ACESSO; }
            set { _DATA_PRIMEIRO_ACESSO = value; }
        }

        public string VERIFICA_COOOKIE
        {
            get { return _VERIFICA_COOOKIE; }
            set { _VERIFICA_COOOKIE = value; }
        }

        public DateTime? DATA_VALIDADE
        {
            get { return _DATA_VALIDADE; }
            set { _DATA_VALIDADE = value; }
        }

        public int? CODIGO_CLIENTE
        {
            get { return _CODIGO_CLIENTE; }
            set { _CODIGO_CLIENTE = value; }
        }

        public int? CONFIG_PLANO_CLIENTE_ID
        {
            get { return _CONFIG_PLANO_CLIENTE_ID; }
            set { _CONFIG_PLANO_CLIENTE_ID = value; }
        }

        public string MASTER
        {
            get { return _MASTER; }
            set { _MASTER = value; }
        }

        public int? SEGURADO_ID
        {
            get { return _SEGURADO_ID; }
            set { _SEGURADO_ID = value; }
        }

        public string FONTE_PAG_ID
        {
            get { return _FONTE_PAG_ID; }
            set { _FONTE_PAG_ID = value; }
        }

        public string CATEGORIA_EFETIVO
        {
            get { return _CATEGORIA_EFETIVO; }
            set { _CATEGORIA_EFETIVO = value; }
        }

        public string CATEGORIA_INATIVO
        {
            get { return _CATEGORIA_INATIVO; }
            set { _CATEGORIA_INATIVO = value; }
        }

        public string CATEGORIA_PENSIONISTA
        {
            get { return _CATEGORIA_PENSIONISTA; }
            set { _CATEGORIA_PENSIONISTA = value; }
        }

        public int? SETOR_ID
        {
            get { return _SETOR_ID; }
            set { _SETOR_ID = value; }
        }

        public string SETOR
        {
            get { return _SETOR; }
            set { _SETOR = value; }
        }

        public string HORA_INI
        {
            get { return _HORA_INI; }
            set { _HORA_INI = value; }
        }

        public string HORA_FIM
        {
            get { return _HORA_FIM; }
            set { _HORA_FIM = value; }
        }

        public string DATA
        {
            get { return _DATA; }
            set { _DATA = value; }
        }
    }
}
