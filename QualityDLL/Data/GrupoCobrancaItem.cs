using System;

namespace Data
{
    //[Serializable]
    public class GrupoCobrancaItem : Base
    {

        public GrupoCobrancaItem() : base()
        {
        }

        private int m_IdGrupoCobrancaItem;
        public int idGrupoCobrancaItem
        {
            get { return this.m_IdGrupoCobrancaItem; }
            set { this.m_IdGrupoCobrancaItem = value; }
        }

        private GrupoCobranca m_IdGrupoCobranca;
        public GrupoCobranca grupoCobranca
        {
            get { return this.m_IdGrupoCobranca; }
            set { this.m_IdGrupoCobranca = value; }
        }

        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        private ParametroBoletoDesconto m_IdParametroBoletoDesconto;
        public ParametroBoletoDesconto parametroBoletoDesconto
        {
            get { return this.m_IdParametroBoletoDesconto; }
            set { this.m_IdParametroBoletoDesconto = value; }
        }

    }
}
