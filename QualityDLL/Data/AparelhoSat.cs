using System;

namespace Data
{
    //[Serializable]
    public class AparelhoSat : Base
    {

        public AparelhoSat() : base()
        {
        }

        private int m_IdAparelhoSat;
        public int idAparelhoSat
        {
            get { return this.m_IdAparelhoSat; }
            set { this.m_IdAparelhoSat = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private string m_Ip;
        public string ip
        {
            get { return this.m_Ip; }
            set { this.m_Ip = value; }
        }

        private int m_Porta;
        public int porta
        {
            get { return this.m_Porta; }
            set { this.m_Porta = value; }
        }

        private int m_modeloDll;
        public int modeloDll
        {
            get { return this.m_modeloDll; }
            set { this.m_modeloDll = value; }
        }

        private string m_CodigoAtivacao;
        public string codigoAtivacao
        {
            get { return this.m_CodigoAtivacao; }
            set { this.m_CodigoAtivacao = value; }
        }

        private string m_signAc;
        public string signAc
        {
            get { return this.m_signAc; }
            set { this.m_signAc = value; }
        }

        private int m_tipoAmbiente;
        public int tipoAmbiente
        {
            get { return this.m_tipoAmbiente; }
            set { this.m_tipoAmbiente = value; }
        }

    }
}
