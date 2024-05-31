using System;

namespace Models
{
    public class ArquivoPessoaModel
    {
        private int? _ARQUIVOS_PESSOAS_ID;
        private int? _PESSOA_ID;
        private string _NAME;
        private DateTime? _DATA;
        private string _MIME;
        private byte[] _DADOS;

        public int? ARQUIVOS_PESSOAS_ID
        {
            get { return _ARQUIVOS_PESSOAS_ID; }
            set { _ARQUIVOS_PESSOAS_ID = value; }
        }
        public int? PESSOA_ID
        {
            get { return _PESSOA_ID; }
            set { _PESSOA_ID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public DateTime? DATA
        {
            get { return _DATA; }
            set { _DATA = value; }
        }
        public string MIME
        {
            get { return _MIME; }
            set { _MIME = value; }
        }
        public byte[] DADOS
        {
            get { return _DADOS; }
            set { _DADOS = value; }
        }
    }
}