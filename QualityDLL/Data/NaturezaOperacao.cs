using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class NaturezaOperacao : Base
    {
        public NaturezaOperacao()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 80),
            TFieldAttributeData(6, true)
        ]
        private int m_IdNaturezaOperacao;
        public int idNaturezaOperacao
        {
            get { return this.m_IdNaturezaOperacao; }
            set { this.m_IdNaturezaOperacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 200),
            TFieldAttributeData(100, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Cod. Reduzido", 120),
            TFieldAttributeData(20, false)
        ]
        private String m_CodigoContabilReduzido;
        public String codigoContabilReduzido
        {
            get { return this.m_CodigoContabilReduzido; }
            set { this.m_CodigoContabilReduzido = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        [
            TFieldAttributeGridDisplay("Pag/Rec", 100),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;R_Receber;P_Pagar")
        ]
        private String m_PagarReceber;
        public String pagarReceber
        {
            get { return this.m_PagarReceber; }
            set { this.m_PagarReceber = value; }
        }

        [
            TFieldAttributeEditDisplay("Exportação Contábil", 100),
            TFieldAttributeGridDisplay("Exportação Contábil", 100),
            TFieldAttributeData(1, false)
        ]
        private bool m_ChkExportacaoContabil;
        public bool chkExportacaoContabil
        {
            get { return this.m_ChkExportacaoContabil; }
            set { this.m_ChkExportacaoContabil = value; }
        }

        [
            TFieldAttributeGridDisplay("Ativo", 100),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;S_Sim;N_Não")
        ]
        private String m_Ativo;
        public String ativo
        {
            get { return this.m_Ativo; }
            set { this.m_Ativo = value; }
        }

        private ParametroAcrescimo m_IdParametroAcrescimo;
        public ParametroAcrescimo parametroAcrescimo
        {
            get { return this.m_IdParametroAcrescimo; }
            set { this.m_IdParametroAcrescimo = value; }
        }
    }
}
