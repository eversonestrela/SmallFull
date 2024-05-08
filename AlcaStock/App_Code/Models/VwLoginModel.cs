using System;

namespace Models
{
    public class VwLoginModel
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

        private int? _PACOTE_ID;

        private int? _SEGURADO_ID;

        private string _TECNICO;

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

        public int? PACOTE_ID
        {
            get { return _PACOTE_ID; }
            set { _PACOTE_ID = value; }
        }

        public int? SEGURADO_ID
        {
            get { return _SEGURADO_ID; }
            set { _SEGURADO_ID = value; }
        }

        public string TECNICO
        {
            get { return _TECNICO; }
            set { _TECNICO = value; }
        }
    }
}