using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [
            TClassAttributeBusinessIdField("m_IdEmpresa")
    ]
    public class PerfilFiscal : Base
    {

        public PerfilFiscal() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPerfilFiscal;
        public int idPerfilFiscal
        {
            get { return this.m_IdPerfilFiscal; }
            set { this.m_IdPerfilFiscal = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 120)
        ]
        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private int m_Sequencia;
        public int sequencia
        {
            get { return this.m_Sequencia; }
            set { this.m_Sequencia = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        private CfOp m_Idcfop;
        public CfOp cfop
        {
            get { return this.m_Idcfop; }
            set { this.m_Idcfop = value; }
        }

        private CstIcms m_Idcsticms;
        public CstIcms cstIcms
        {
            get { return this.m_Idcsticms; }
            set { this.m_Idcsticms = value; }
        }

        private CstPis m_Idcstpis;
        public CstPis cstPis
        {
            get { return this.m_Idcstpis; }
            set { this.m_Idcstpis = value; }
        }

        private CstCofins m_Idcstcofins;
        public CstCofins cstCofins
        {
            get { return this.m_Idcstcofins; }
            set { this.m_Idcstcofins = value; }
        }

        private CstIpi m_Idcstipi;
        public CstIpi cstIpi
        {
            get { return this.m_Idcstipi; }
            set { this.m_Idcstipi = value; }
        }

        private string m_Tipo;
        public string tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        private string m_Icms;
        public string icms
        {
            get { return this.m_Icms; }
            set { this.m_Icms = value; }
        }

        private string m_Icmsst;
        public string icmsSt
        {
            get { return this.m_Icmsst; }
            set { this.m_Icmsst = value; }
        }

        private string m_Ipi;
        public string ipi
        {
            get { return this.m_Ipi; }
            set { this.m_Ipi = value; }
        }

        private string m_Icmssipi;
        public string icmsSIpi
        {
            get { return this.m_Icmssipi; }
            set { this.m_Icmssipi = value; }
        }

        private string m_Redbcicms;
        public string redBcIcms
        {
            get { return this.m_Redbcicms; }
            set { this.m_Redbcicms = value; }
        }

        private string m_Redbcicmsst;
        public string redBCIcmsSt
        {
            get { return this.m_Redbcicmsst; }
            set { this.m_Redbcicmsst = value; }
        }

        private string m_Icmsdiferido;
        public string icmsDiferido
        {
            get { return this.m_Icmsdiferido; }
            set { this.m_Icmsdiferido = value; }
        }

        private string m_Fcpicms;
        public string fcpIcms
        {
            get { return this.m_Fcpicms; }
            set { this.m_Fcpicms = value; }
        }

        private string m_Fcpicmsst;
        public string fcpIcmsSt
        {
            get { return this.m_Fcpicmsst; }
            set { this.m_Fcpicmsst = value; }
        }

        private string m_AplicarAliquotaicms;
        public string aplicarAliquotaIcms
        {
            get { return this.m_AplicarAliquotaicms; }
            set { this.m_AplicarAliquotaicms = value; }
        }

        private double m_Aliquotaicms;
        public double aliquotaIcms
        {
            get { return this.m_Aliquotaicms; }
            set { this.m_Aliquotaicms = value; }
        }

        private string m_Aplicaraliquotaicmsst;
        public string aplicarAliquotaIcmsSt
        {
            get { return this.m_Aplicaraliquotaicmsst; }
            set { this.m_Aplicaraliquotaicmsst = value; }
        }

        private double m_Aliquotaicmsst;
        public double aliquotaIcmsSt
        {
            get { return this.m_Aliquotaicmsst; }
            set { this.m_Aliquotaicmsst = value; }
        }

    }
}
