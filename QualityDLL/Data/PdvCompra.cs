using System;
using System.Data;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PdvCompra : Base
    {
        public PdvCompra() : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 70),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPdvCompra;
        public int idPdvCompra
        {
            get { return this.m_IdPdvCompra; }
            set { this.m_IdPdvCompra = value; }
        }

        [
            TFieldAttributeGridDisplay("Data", 100),
            TFieldAttributeFormat("dd/MM/yyyy HH:mm:ss", "date")
        ]
        private DateTime m_DataCompra;
        public DateTime dataCompra
        {
            get { return this.m_DataCompra; }
            set { this.m_DataCompra = value; }
        }

        private String m_NumeroDocumento;
        public String numeroDocumento
        {
            get { return this.m_NumeroDocumento; }
            set { this.m_NumeroDocumento = value; }
        }

        private String m_CpfCnpj;
        public String cpfCnpj
        {
            get { return this.m_CpfCnpj; }
            set { this.m_CpfCnpj = value; }
        }

        [
            TFieldAttributeGridDisplay("Status", 100)
        ]
        private String m_StatusCompra;
        public String statusCompra
        {
            get { return this.m_StatusCompra; }
            set { this.m_StatusCompra = value; }
        }

        [
            TFieldAttributeGridDisplay("Cliente", 200),
            TFieldAttributeSubfield("idPessoa:pessoa.nomeRazaoSocial")
        ]
        private EmpresaRelacionamento m_IdPessoaFisicaJuridica;
        public EmpresaRelacionamento pessoaFisicaJuridica
        {
            get { return this.m_IdPessoaFisicaJuridica; }
            set { this.m_IdPessoaFisicaJuridica = value; }
        }

        private RequisicaoInterna m_requisicaoInterna;
        public RequisicaoInterna requisicaoInterna
        {
            get { return this.m_requisicaoInterna; }
            set { this.m_requisicaoInterna = value; }
        }

        private PdvCompraTaxaServico[] m_pdvCompraTaxaServico;
        public PdvCompraTaxaServico[] pdvCompraTaxaServico
        {
            get { return this.m_pdvCompraTaxaServico; }
            set { this.m_pdvCompraTaxaServico = value; }
        }

        [
            TFieldAttributeGridDisplay("Estação", 200),
            TFieldAttributeSubfield("idPdvEstacao:descricao")
        ]
        private PdvEstacao m_IdPdvEstacao;
        public PdvEstacao pdvEstacao
        {
            get { return this.m_IdPdvEstacao; }
            set { this.m_IdPdvEstacao = value; }
        }

        private ContasAReceber m_idContasAReceber;
        public ContasAReceber contasAReceber
        {
            get { return this.m_idContasAReceber; }
            set { this.m_idContasAReceber = value; }
        }

        [
            TFieldAttributeGridDisplay("Número da Comanda", 200)
        ]
        private String m_numeroComanda;
        public String numeroComanda
        {
            get { return this.m_numeroComanda; }
            set { this.m_numeroComanda = value; }
        }

        private PdvCompraCupom[] m_PdvCompraCupons;
        public PdvCompraCupom[] pdvCompraCupons
        {
            get { return this.m_PdvCompraCupons; }
            set { this.m_PdvCompraCupons = value; }
        }

        private PdvCompraStatus[] m_PdvCompraStatus;
        public PdvCompraStatus[] pdvCompraStatus
        {
            get { return this.m_PdvCompraStatus; }
            set { this.m_PdvCompraStatus = value; }
        }



        [
            TFieldAttributeGridDisplay("Valor", 55),
            TFieldAttributeFormat("C2", "money")
        ]
        private Double m_Total;
        public Double total
        {
            get { return this.m_Total; }
            set { this.m_Total = value; }
        }

        private Pos m_IdPos;
        public Pos pos
        {
            get { return this.m_IdPos; }
            set { this.m_IdPos = value; }
        }

        private FormaPagamento[] m_FormaPagamentos;
        public FormaPagamento[] formaPagamentos
        {
            get { return this.m_FormaPagamentos; }
            set { this.m_FormaPagamentos = value; }
        }


        public bool isVendaLiberada()
        {
            DataTable results = Utils.Utils.em.executeData(String.Format("SELECT vendaLiberada FROM pdvCompra WHERE idPdvCompra = {0}", this.m_IdPdvCompra.ToString()), null);
            if (results != null)
                return Convert.ToBoolean(results.Rows[0][0]);
            return false;
        }

        public void bloquearVenda()
        {
            DataTable results = Utils.Utils.em.executeData(String.Format("update pdvCompra set vendaLiberada = 0 WHERE idPdvCompra = {0}", this.m_IdPdvCompra.ToString()), null);
        }
        public void liberarVenda()
        {
            DataTable results = Utils.Utils.em.executeData(String.Format("update pdvCompra set vendaLiberada = 1 WHERE idPdvCompra = {0}", this.m_IdPdvCompra.ToString()), null);
        }


    }
}
