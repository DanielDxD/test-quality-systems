using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class TipoRelacionamento: Base
	{
		public TipoRelacionamento(): base()
		{
		}

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdTipoRelacionamento;
		public int idTipoRelacionamento
		{
			get{return this.m_IdTipoRelacionamento;}
			set{this.m_IdTipoRelacionamento = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 190),
            TFieldAttributeData( 50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
		}

        [
            TFieldAttributeGridDisplay("Físico/Jurídico", 123),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;F_Físico;J_Jurídico")
        ]
        private String m_Pfpj;
		public String pfpj
		{
			get{return this.m_Pfpj;}
			set{this.m_Pfpj = value;}
		}

        [
            TFieldAttributeGridDisplay("Estado Civil", 103),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idEstadoCivil:descricao")
        ]
        private EstadoCivil m_IdEstadoCivil;
		public EstadoCivil estadoCivil
		{
			get{return this.m_IdEstadoCivil;}
			set{this.m_IdEstadoCivil = value;}
		}

        private bool m_Presidente;
        public bool presidente
        {
            get { return this.m_Presidente; }
            set { this.m_Presidente = value; }
        }

        public override string ToString()
        {
            return this.m_IdTipoRelacionamento.ToString();
        }
    }
}
