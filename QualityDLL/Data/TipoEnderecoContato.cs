using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class TipoEnderecoContato: Base
	{
		public TipoEnderecoContato(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdTipoEnderecoContato;
		public int idTipoEnderecoContato
		{
			get{return this.m_IdTipoEnderecoContato;}
			set{this.m_IdTipoEnderecoContato = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 270),
            TFieldAttributeData(50, true)
        ]
		private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Endereço/Contato", 143),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;E_Endereço;C_Contato")
        ]
        private String m_EnderecoContato;
		public String enderecoContato
		{
			get{return this.m_EnderecoContato;}
			set{this.m_EnderecoContato = value;}
		}

        public override string ToString()
        {
            return this.m_IdTipoEnderecoContato.ToString();
        }
	}
}
