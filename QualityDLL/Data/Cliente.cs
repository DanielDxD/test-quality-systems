using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [
        TClassAttributeFields
        (
            new String[]
                {
                    ".m_IdEmpresaRelacionamento",
                    ".m_IdPessoa"
                }
        ),
        TClassAttributeBusinessIdField("m_IdEmpresa")
    ]
    public class Cliente : EmpresaRelacionamento
    {
        public Cliente() : base()
        {
        }

        private DateTime m_DataContrato;
        public DateTime dataContrato
        {
            get { return this.m_DataContrato; }
            set { this.m_DataContrato = value; }
        }

        private bool m_RetemISS;
        public bool retemISS
        {
            get { return this.m_RetemISS; }
            set { this.m_RetemISS = value; }
        }

        private string m_RecebimentoPDV;
        public string recebimentoPDV
        {
            get { return this.m_RecebimentoPDV; }
            set { this.m_RecebimentoPDV = value; }
        }

        private RegraContabilizacao m_IdRegraContabilizacao;
        public RegraContabilizacao regraContabilizacao
        {
            get { return this.m_IdRegraContabilizacao; }
            set { this.m_IdRegraContabilizacao = value; }
        }

        private TipoMovimentoContabil m_IdTipoMovimentoContabil;
        public TipoMovimentoContabil tipoMovimentoContabil
        {
            get { return this.m_IdTipoMovimentoContabil; }
            set { this.m_IdTipoMovimentoContabil = value; }
        }

        private PlanoContas m_IdPlanoContas;
        public PlanoContas planoContas
        {
            get { return this.m_IdPlanoContas; }
            set { this.m_IdPlanoContas = value; }
        }

        public override string ToString()
        {
            return this.idEmpresaRelacionamento.ToString();
        }
    }
}
