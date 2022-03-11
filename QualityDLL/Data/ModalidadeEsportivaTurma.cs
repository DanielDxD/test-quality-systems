
using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class ModalidadeEsportivaTurma : Base
	{
		public ModalidadeEsportivaTurma() : base() {}

		[
			TFieldAttributeKey(true, true)
		]
		private int m_IdModalidadeEsportivaTurma;
		public int idModalidadeEsportivaTurma 
		{ 
			get { return this.m_IdModalidadeEsportivaTurma; } 
			set { this.m_IdModalidadeEsportivaTurma = value; } 
		}

		private ModalidadeEsportiva m_IdModalidadeEsportiva;
		public ModalidadeEsportiva modalidadeEsportiva 
		{ 
			get { return this.m_IdModalidadeEsportiva; } 
			set { this.m_IdModalidadeEsportiva = value; } 
		}

		private DateTime m_HorarioInicial;
		public DateTime horarioInicial 
		{ 
			get { return this.m_HorarioInicial; } 
			set { this.m_HorarioInicial = value; } 
		}

		private DateTime m_HorarioFinal;
		public DateTime horarioFinal 
		{ 
			get { return this.m_HorarioFinal; } 
			set { this.m_HorarioFinal = value; } 
		}

		private int m_ToleranciaInicial;
		public int toleranciaInicial 
		{ 
			get { return this.m_ToleranciaInicial; } 
			set { this.m_ToleranciaInicial = value; } 
		}

		private int m_ToleranciaFinal;
		public int toleranciaFinal 
		{ 
			get { return this.m_ToleranciaFinal; } 
			set { this.m_ToleranciaFinal = value; } 
		}

		private Funcionario m_IdFuncionario;
		public Funcionario funcionario 
		{ 
			get { return this.m_IdFuncionario; } 
			set { this.m_IdFuncionario = value; } 
		}

		private int m_LimiteAlunos;
		public int limiteAlunos 
		{ 
			get { return this.m_LimiteAlunos; } 
			set { this.m_LimiteAlunos = value; } 
		}

		private string m_NivelTurma;
		public string nivelTurma 
		{ 
			get { return this.m_NivelTurma; } 
			set { this.m_NivelTurma = value; } 
		}

		private string m_Observacoes;
		public string observacoes 
		{ 
			get { return this.m_Observacoes; } 
			set { this.m_Observacoes = value; } 
		}

		private string m_TipoControleFrequencia;
		public string tipoControleFrequencia 
		{ 
			get { return this.m_TipoControleFrequencia; } 
			set { this.m_TipoControleFrequencia = value; } 
		}

		private int m_QtdLimite;
		public int qtdLimite 
		{ 
			get { return this.m_QtdLimite; } 
			set { this.m_QtdLimite = value; } 
		}

		private bool m_Domingo;
		public bool domingo 
		{ 
			get { return this.m_Domingo; } 
			set { this.m_Domingo = value; } 
		}

		private bool m_Segunda;
		public bool segunda 
		{ 
			get { return this.m_Segunda; } 
			set { this.m_Segunda = value; } 
		}

		private bool m_Terca;
		public bool terca 
		{ 
			get { return this.m_Terca; } 
			set { this.m_Terca = value; } 
		}

		private bool m_Quarta;
		public bool quarta 
		{ 
			get { return this.m_Quarta; } 
			set { this.m_Quarta = value; } 
		}

		private bool m_Quinta;
		public bool quinta 
		{ 
			get { return this.m_Quinta; } 
			set { this.m_Quinta = value; } 
		}

		private bool m_Sexta;
		public bool sexta 
		{ 
			get { return this.m_Sexta; } 
			set { this.m_Sexta = value; } 
		}

		private bool m_Sabado;
		public bool sabado 
		{ 
			get { return this.m_Sabado; } 
			set { this.m_Sabado = value; } 
		}

		private NaturezaOperacao m_IdNaturezaOperacaoMatricula;
		public NaturezaOperacao naturezaOperacaoMatricula 
		{ 
			get { return this.m_IdNaturezaOperacaoMatricula; } 
			set { this.m_IdNaturezaOperacaoMatricula = value; } 
		}

		private double m_ValorMatriculaSocio;
		public double valorMatriculaSocio 
		{ 
			get { return this.m_ValorMatriculaSocio; } 
			set { this.m_ValorMatriculaSocio = value; } 
		}

		private double m_ValorMatriculaNaoSocio;
		public double valorMatriculaNaoSocio 
		{ 
			get { return this.m_ValorMatriculaNaoSocio; } 
			set { this.m_ValorMatriculaNaoSocio = value; } 
		}

		private string m_Situacao;
		public string situacao 
		{ 
			get { return this.m_Situacao; } 
			set { this.m_Situacao = value; } 
		}

        private ModalidadeEsportivaTurmaValor[] m_Valores;
        public ModalidadeEsportivaTurmaValor[] valores
        {
            get { return this.m_Valores; }
            set { this.m_Valores = value; }
        }

        private Double m_ValorSocio;
        public Double valorSocio
        {
            get { return this.m_ValorSocio; }
            set { this.m_ValorSocio = value; }
        }

        private Double m_ValorNaoSocio;
        public Double valorNaoSocio
        {
            get { return this.m_ValorNaoSocio; }
            set { this.m_ValorNaoSocio = value; }
        }

    }
}
