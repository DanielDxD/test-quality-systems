using System;

namespace Data
{
    //[Serializable]
    public class PixTransacao : Base
    {

        public PixTransacao() : base()
        {
        }

        private int m_IdPixTransacao;
        public int idPixTransacao
        {
            get { return this.m_IdPixTransacao; }
            set { this.m_IdPixTransacao = value; }
        }

        private Pix m_IdPix;
        public Pix pix
        {
            get { return this.m_IdPix; }
            set { this.m_IdPix = value; }
        }

        private string m_EndToEndId;
        public string endToEndId
        {
            get { return this.m_EndToEndId; }
            set { this.m_EndToEndId = value; }
        }

        private decimal m_Valor;
        public decimal valor
        {
            get { return this.m_Valor; }
            set { this.m_Valor = value; }
        }

        private DateTime m_Horario;
        public DateTime horario
        {
            get { return this.m_Horario; }
            set { this.m_Horario = value; }
        }

        private string m_PagadorCpfCnpj;
        public string pagadorCpfCnpj
        {
            get { return this.m_PagadorCpfCnpj; }
            set { this.m_PagadorCpfCnpj = value; }
        }

        private string m_PagadorNome;
        public string pagadorNome
        {
            get { return this.m_PagadorNome; }
            set { this.m_PagadorNome = value; }
        }

    }
}
