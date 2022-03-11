using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class Situacao: Base
	{
		public Situacao(): base()
		{
		}

		[
			TFieldAttributeGridDisplay("ID", 55),
			TFieldAttributeData(6, true),
			TFieldAttributeKey(true, true)
		]
		private int m_IdSituacao;
		public int idSituacao
		{
			get{return this.m_IdSituacao;}
			set{this.m_IdSituacao = value;}
		}

		[
			TFieldAttributeGridDisplay("Descrição", 100),
			TFieldAttributeData(20, false)
		]
		private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

		[
			TFieldAttributeGridDisplay("Tipo de Situação", 200),
			TFieldAttributeSubfield("idTipoSituacao:descricao")
		]
		private TipoSituacao m_IdTipoSituacao;
		public TipoSituacao tipoSituacao
		{
			get{return this.m_IdTipoSituacao; }
			set{this.m_IdTipoSituacao = value;}
		}

        public override string ToString()
        {
            return this.m_IdSituacao.ToString();
        }
    }
}
