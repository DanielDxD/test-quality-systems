using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class ModalidadeEsportiva : Base
	{
		public ModalidadeEsportiva() : base() {}

		[
			TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
		private int m_IdModalidadeEsportiva;
		public int idModalidadeEsportiva 
		{ 
			get { return this.m_IdModalidadeEsportiva; } 
			set { this.m_IdModalidadeEsportiva = value; } 
		}

        [
            TFieldAttributeGridDisplay("Descrição", 200)
        ]
        private string m_Descricao;
		public string descricao 
		{ 
			get { return this.m_Descricao; } 
			set { this.m_Descricao = value; } 
		}

        [
            TFieldAttributeGridDisplay("Idade Mínima", 60)
        ]
        private int m_IdadeMinima;
		public int idadeMinima 
		{ 
			get { return this.m_IdadeMinima; } 
			set { this.m_IdadeMinima = value; } 
		}

        [
            TFieldAttributeGridDisplay("Idade Máxima", 60)
        ]
        private int m_IdadeMaxima;
		public int idadeMaxima 
		{ 
			get { return this.m_IdadeMaxima; } 
			set { this.m_IdadeMaxima = value; } 
		}
        
        private string m_Situacao;
        public string situacao
        {
            get { return this.m_Situacao; }
            set { this.m_Situacao = value; }
        }

        [
            TFieldAttributeGridDisplay("Situação", 60)
        ]
        private string m_SituacaoView;
        public string situacaoView
        {
            get { return this.m_SituacaoView; }
            set { this.m_SituacaoView = value; }
        }

        private ModalidadeEsportivaTurma[] m_Turmas;
        public ModalidadeEsportivaTurma[] turmas
        {
            get { return this.m_Turmas; }
            set { this.m_Turmas = value; }
        }

	}
}
