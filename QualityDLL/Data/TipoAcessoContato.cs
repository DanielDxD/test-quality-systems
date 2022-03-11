using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class TipoAcessoContato: Base
	{
		public TipoAcessoContato(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
		private int m_IdTipoAcessoContato;
		public int idTipoAcessoContato
		{
			get{return this.m_IdTipoAcessoContato;}
			set{this.m_IdTipoAcessoContato = value;}
		}

        [
            TFieldAttributeGridDisplay("Tipo", 123),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;F_Telefone Fixo;C_Telefone Celular;E_Email;O_Outros")
        ]
        private String m_Tipo;
		public String tipo
		{
			get{return this.m_Tipo;}
			set{this.m_Tipo = value;}
		}

        [
            TFieldAttributeGridDisplay("Descricao", 285),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        public override string ToString()
        {
            return this.m_IdTipoAcessoContato.ToString();
        }
	}
}
