using System;

namespace Data
{
    //[Serializable]
    public class PdvEstacaoCategoria : Base
    {

        public PdvEstacaoCategoria() : base()
        {
        }

        private int m_IdPdvEstacaoCategoria;
        public int idPdvEstacaoCategoria
        {
            get { return this.m_IdPdvEstacaoCategoria; }
            set { this.m_IdPdvEstacaoCategoria = value; }
        }

        private PdvEstacao m_IdPdvEstacao;
        public PdvEstacao pdvEstacao
        {
            get { return this.m_IdPdvEstacao; }
            set { this.m_IdPdvEstacao = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private byte[] m_Icone;
        public byte[] icone
        {
            get { return this.m_Icone; }
            set { this.m_Icone = value; }
        }

        private PdvEstacaoCategoria m_IdPdvEstacaoCategoriaPai;
        public PdvEstacaoCategoria pdvEstacaoCategoriaPai
        {
            get { return this.m_IdPdvEstacaoCategoriaPai; }
            set { this.m_IdPdvEstacaoCategoriaPai = value; }
        }

    }
}
