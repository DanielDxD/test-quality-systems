using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class TipoProdutoServico: Base
	{
		public TipoProdutoServico(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdTipoProdutoServico;
		public int idTipoProdutoServico
		{
			get{return this.m_IdTipoProdutoServico;}
			set{this.m_IdTipoProdutoServico = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 300),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Tipo", 123),
            TFieldAttributeData(1, true),
           // TFieldAttributeSubfield("ItemGenerico:_Selecione;C_Consumo;E_Escritório;A_Alimentação;H_Higiene;S_Servico;O_Outros")
        ]
        private String m_Tipo;
		public String tipo
		{
			get{return this.m_Tipo;}
			set{this.m_Tipo = value;}
		}

        public override string ToString()
        {
            return this.m_IdTipoProdutoServico.ToString();
        }
    }
}
