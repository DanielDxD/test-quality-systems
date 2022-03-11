using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class RequisicaoInterna: Base
	{
		public RequisicaoInterna(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRequisicaoInterna;
		public int idRequisicaoInterna
		{
			get{return this.m_IdRequisicaoInterna;}
			set{this.m_IdRequisicaoInterna = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 200),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Data", 120),
            TFieldAttributeData(50, false),
            TFieldAttributeFormat("dd/MM/yyyy")
        ]
        private DateTime m_DataRequisicao;
		public DateTime dataRequisicao
		{
			get{return this.m_DataRequisicao;}
			set{this.m_DataRequisicao = value;}
		}

        [
            TFieldAttributeGridDisplay("Tipo", 100),
            TFieldAttributeData(1, false),
            TFieldAttributeSubfield("ItemGenerico:C_Consumo;T_Transferência;S_Saída;E_Entrada")
        ]
        private String m_Tipo;
		public String tipo
		{
			get{return this.m_Tipo;}
			set{this.m_Tipo = value;}
		}

		private Departamento m_IdDepartamentoOrigem;
		public Departamento departamentoOrigem
		{
			get{return this.m_IdDepartamentoOrigem;}
			set{this.m_IdDepartamentoOrigem = value;}
        }

        private Funcionario m_IdFuncionarioSolicitante;
        public Funcionario funcionarioSolicitante
        {
            get { return this.m_IdFuncionarioSolicitante; }
            set { this.m_IdFuncionarioSolicitante = value; }
        }

        private Departamento m_IdDepartamentoDestino;
		public Departamento departamentoDestino
		{
			get{return this.m_IdDepartamentoDestino;}
			set{this.m_IdDepartamentoDestino = value;}
		}

        //idRequisicaoInterna
        private RequisicaoInternaSituacao[] m_RequisicaoInternaSituacaos;
        public RequisicaoInternaSituacao[] requisicaoInternaSituacaos
        {
            get{return this.m_RequisicaoInternaSituacaos;}
            set{this.m_RequisicaoInternaSituacaos = value;}
        }

        //idRequisicaoInterna
        private RequisicaoInternaProdutoServico[] m_RequisicaoInternaProdutoServicos;
        public RequisicaoInternaProdutoServico[] requisicaoInternaProdutoServicos
        {
            get{return this.m_RequisicaoInternaProdutoServicos;}
            set{this.m_RequisicaoInternaProdutoServicos = value;}
        }

        public override string ToString()
        {
            return this.m_IdRequisicaoInterna.ToString();
        }
    }
}
