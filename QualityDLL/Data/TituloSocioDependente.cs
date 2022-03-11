using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
    public class TituloSocioDependente: Base
    {
		public TituloSocioDependente(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdTituloSocioDependente;
        public int idTituloSocioDependente
        {
            get { return this.m_IdTituloSocioDependente; }
            set { this.m_IdTituloSocioDependente = value; }
        }

        private TituloSocio m_IdTituloSocio;
		public TituloSocio tituloSocio
		{
			get{return this.m_IdTituloSocio; }
			set{this.m_IdTituloSocio = value;}
		}

        [
            TFieldAttributeGridDisplay("Nome", 200)
        ]
        private String m_Nome;
        public String nome
        {
            get { return this.m_IdTituloSocio.titularEmpresaRelacionamento.pessoa.nomeRazaoSocial; }
        }

        [
            TFieldAttributeGridDisplay("Tipo de Relacionamento", 255),
            TFieldAttributeSubfield("idTipoRelacionamento:descricao")
        ]
        private TipoRelacionamento m_IdTipoRelacionamento;
		public TipoRelacionamento tipoRelacionamento
        {
			get{return this.m_IdTipoRelacionamento; }
			set{this.m_IdTipoRelacionamento = value;}
        }

       

        public override string ToString()
        {
            return this.m_IdTituloSocio.ToString();
        }
    }
}
